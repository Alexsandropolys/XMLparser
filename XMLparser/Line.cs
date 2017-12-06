using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    public class Line
    {
        public Line(Dot begin, Dot end, AbstractPoly owner)
        {
            this.begin = begin;
            this.end = end;
            this.owner = owner;
        }

        public Line(Dot begin, Dot end)
        {
            this.begin = begin;
            this.end = end;
        }


        public Dot begin;
        public Dot end;
        public AbstractPoly owner;
    }
}
