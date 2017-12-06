using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    public class Dot
    {
        public Dot(int _number, double _x, double _y, AbstractPoly _owner)
        {
            this.x = _x;
            this.y = _y;
            this.number = _number;
            this.owner = _owner;
        }

        public Dot( int number, double Lat, double Long)
        {
            this.Lat = Lat;
            this.Long = Long;
            this.number = number;
        }

        public int number { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }

        /*
        public double Lat { get; set; }
        public double Long { get; set; }
        */
        public AbstractPoly owner { get; set; }

    }
}
