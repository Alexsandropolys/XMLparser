using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    class SafeZone : AbstractPoly
    {

        public List<Dot> dots = new List<Dot>();

        override public void AddDot(Dot dot)
        {
            dots.Add(dot);
        }

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

    }
}
