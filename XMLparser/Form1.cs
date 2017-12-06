using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections;
using Word = Microsoft.Office.Interop.Word;

namespace XMLparser
{
    public partial class Form1 : Form
    {
        double LatInit = 56.374;
        double LongInit = 85.414;
        String ChooseMap = "";
        List<Parcel> parcels;

        public Form1()
        {
            InitializeComponent();

        }
        
        void WorksWithMap()
        {
            string tubeName = "";
            switch (TubeBox.Text)
            {
                case "Газораспределение 2 м.":
                    { tubeName = "2.xml"; }
                    break;
                case "Подземное газораспределение (ПЭТ + медный провод) 2.5 м":
                    { tubeName = "2.5.xml"; }
                    break;
                case "Воздушная линия 10 КилоВольт 10 м.":
                    { tubeName = "10.xml"; }
                    break;
                case "Магистральный газопровод 25 м.":
                    { tubeName = "25.xml"; }
                    break;
                case "Охранная зона 50 м.":
                    { tubeName = "50.xml"; }
                    break;
            }

            Parser zoneParser = new Parser("Tubes\\" + tubeName);
            List<SafeZone> safeZones = zoneParser.ParseTube();

            Parser ParcelParser = new Parser("fullMap.xml");
            parcels = ParcelParser.Parse();

            
            
            foreach (Parcel pl in parcels)
            {
                Checker ch = new Checker();
                ch.Check(safeZones[0], pl);
            }
            
            Printer prnt = new Printer();
            prnt.InitMap(gMapControl1, LatInit, LongInit, ChooseMapBox.Text);


            prnt.showSafeZone(gMapControl1, Color.Orange, safeZones[0]);
            prnt.showParcels(gMapControl1, Color.Green, parcels);

            CrossedListBox.Items.Clear();
            foreach (Parcel pl in parcels)
            {
                if (pl.isCrossed)
                {
                    CrossedListBox.Items.Add(pl.cadastralNumber);
                }
            }
            gMapControl1.Zoom = 15;
            gMapControl1.Zoom = 16;
        }

        public void ShowDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xml files (*.xml)|";
            ofd.InitialDirectory = "c:\\GIS";
            ofd.Title = "Выбирете файл карты";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                this.Close();

            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.Filter = "xml files (*.xml)|";
            ofd2.InitialDirectory = "c:\\GIS";
            ofd2.Title = "Выбирете файл трубопровода";
            if (ofd2.ShowDialog() == DialogResult.Cancel)
                this.Close();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
           // ShowDialog();
            WorksWithMap();
        }

        private void ChooseMapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChooseMap = ChooseMapBox.Text;
            WorksWithMap();
        }

        private void TubeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorksWithMap();
        }

        private void CrossedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parcel selectedParcel = new Parcel();

            if (CrossedListBox.SelectedItem != null)
            {
                foreach (Parcel pl in parcels)
                {
                    if (pl.cadastralNumber.Equals(CrossedListBox.SelectedItem.ToString()))
                    {
                        selectedParcel = pl;
                        break;
                    }
                }
                Form info = new Form2(selectedParcel);
                info.ShowDialog();
            }

        }

        private void gMapControl1_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            if(item.Name == "safeZone")
            {
                Form TubeForm = new TubeInformation(TubeBox.SelectedIndex.ToString());
                TubeForm.ShowDialog();
                return;
            }
            Parcel selectedParcel = new Parcel();

            foreach (Parcel pl in parcels)
            {
                if (pl.cadastralNumber.Equals(item.Name))
                {
                    selectedParcel = pl;
                    break;
                }
            }
            Form info = new Form2(selectedParcel);
            info.ShowDialog();
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            bool contains = false;
            foreach (Parcel pl in parcels)
            {
                if (pl.isCrossed)
                {
                    contains = true;
                }
            }

            if (contains)
            {
                Word.Application app = new Word.Application();
                Word.Document doc = app.Documents.Add();

                int count = 0;
                foreach (Parcel pl in parcels)
                {
                    if (pl.isCrossed)
                    {
                        doc.Paragraphs[1].Range.Text += Environment.NewLine;
                        doc.Paragraphs[1].Range.Text += "Описание: " + pl.note + Environment.NewLine;
                        doc.Paragraphs[1].Range.Text += "Регион: " + pl.region + Environment.NewLine;
                        doc.Paragraphs[1].Range.Text +=  "ОКАТО: " + pl.okato + Environment.NewLine;
                        doc.Paragraphs[1].Range.Text += pl.cadastralNumber+ Environment.NewLine;
                        doc.Paragraphs[1].Range.Text += CrossedListBox.Items.Count - count++ + ") \n";
                    }
                }
                app.Visible = true;
            }
            else
            {
                MessageBox.Show("Список пересеченных участков пуст", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void gMapControl1_OnMapZoomChanged()
        {

        }
    }
}
