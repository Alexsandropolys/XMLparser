using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    public class Parcel : AbstractPoly
    {
        public List<Dot> dots = new List<Dot>();

        public Parcel()
        {
        }


        public Parcel(string _cadastralNumber, string _okato, int _region, string _note)
        {
            this.cadastralNumber = _cadastralNumber;
            this.okato = _okato;
            this.region = _region;
            this.note = _note;
        }

        public bool isCrossed = false;

        public List<Line> GetLines()
        {
            List<Line> result = new List<Line>();
            for (int i = 0; i < dots.Count - 1; i++)
            {
                Line ln = new Line(dots[i], dots[i + 1], this);
                result.Add(ln);
            }
            return result;
        }
        override public void  AddDot(Dot dot)
        {
            dots.Add(dot);
        }
        public string cadastralNumber { get; set; }
        public string okato { get; set; }
        public int region { get; set; }
        public string note { get; set; }
    }
}
