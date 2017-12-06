using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    class Parser
    {
        public List<Parcel> parcels = new List<Parcel>();
        public List<SafeZone> safeZones = new List<SafeZone>();
        
        string nameOfFile;

        public Parser(string _nameOfFile)
        {
            this.nameOfFile = _nameOfFile;
        }
        
        public List<SafeZone> ParseTube()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(nameOfFile);
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode currentNode = null;

            //currentNode = GetNode(xRoot, "fme:featureMember");
            foreach (XmlNode bigNode in xRoot.ChildNodes)
            {
                if (bigNode.Name == "fme:featureMember")
                {
                    currentNode = bigNode;
                    currentNode = currentNode.FirstChild;
                    currentNode = GetNode(currentNode, "fme:surfaceProperty");
                    currentNode = GetNode(currentNode, "gml:Surface");
                    currentNode = GetNode(currentNode, "gml:patches");
                    currentNode = GetNode(currentNode, "gml:PolygonPatch");
                    currentNode = GetNode(currentNode, "gml:exterior");
                    currentNode = GetNode(currentNode, "gml:LinearRing");
                    currentNode = GetNode(currentNode, "gml:posList");

                    string beforeParsing = currentNode.InnerText;
                    List<string> strList = beforeParsing.Split(' ').ToList();

                    int i = 0;
                    SafeZone safeZone = new SafeZone();

                    double x = -1;
                    double y = -1;
                    foreach (string str in strList)
                    {
                        if (i++ % 2 == 0)
                        {
                            x = Convert.ToDouble(str);
                        }
                        else
                        {
                            y = Convert.ToDouble(str);
                        }

                        if (x > 0 && y > 0)
                        {
                            Dot dot = new Dot(i, x, y, safeZone);
                            dot.Lat = x;
                            dot.Long = y;
                            safeZone.AddDot(dot);
                            x = -1;
                            y = -1;
                        }
                    }

                    safeZones.Add(safeZone);
                }
            }
            return safeZones;
        }



       
        private XmlNode GetNode(XmlNode currentNode, string nameOfNode)
        {
            foreach (XmlNode node in currentNode.ChildNodes)
            {
                if (node.Name == nameOfNode)
                {
                    return node;
                }
            }
            return null;
        }

        public List<Parcel> Parse()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(nameOfFile);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode Parcels = xRoot.ChildNodes.Item(0).ChildNodes.Item(0).ChildNodes.Item(1);

            foreach (XmlNode xnode in Parcels)
            {

                string CadastralNumber = Convert.ToString(xnode.Attributes.Item(0).Value);
                string Okato = "";
                int Region = 0;
                string Note = "";
                foreach (XmlNode node in xnode.ChildNodes.Item(2).ChildNodes)
                {
                    if (node.Name == "Address")
                    {
                        Okato = node.FirstChild.InnerText;
                        Region = Convert.ToInt32(node.ChildNodes.Item(2).InnerText);
                        Note = node.LastChild.InnerText;
                    }
                }



                XmlNode SpatialElement = null;
                if (xnode.ChildNodes.Count >= 7)
                {
                    SpatialElement = xnode.ChildNodes.Item(6).ChildNodes.Item(0);
                }

                if (SpatialElement != null)
                {
                    Parcel parcel = new Parcel(CadastralNumber, Okato, Region, Note);
                    foreach (XmlNode Point in SpatialElement)
                    {

                        string number = Convert.ToString(Point.Attributes.Item(1).Value);
                        string X = Convert.ToString(Point.ChildNodes.Item(0).Attributes.Item(1).Value);
                        string Y = Convert.ToString(Point.ChildNodes.Item(0).Attributes.Item(0).Value);
                        Dot dot = new Dot(Convert.ToInt32(number), Convert.ToDouble(X),
                            Convert.ToDouble(Y), parcel);
                        dot.Long = dot.x / 50973.64701411002;
                        dot.Lat = (dot.y + 4000000) / 76961.68783173309;
                        parcel.AddDot(dot);
                    }
                    parcels.Add(parcel);
                    
                }


            }
            return parcels;
        }
    }
}
