using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLparser
{
    class Checker
    {
        public void Check(SafeZone sz, Parcel pl)
        {

            foreach(Line ln in sz.GetLines())
            {
                foreach(Line tn in pl.GetLines())
                {
                    if (CheckLine(ln, tn))
                    {
                        pl.isCrossed = true;
                        break;
                    }
                }
            }

        }

        private bool CheckLine(Line t, Line r)
        {
            bool bl = intersect(t.begin, t.end, r.begin, r.end);
            return bl;
        }

        private double area(Dot a, Dot b, Dot c)
        {
            return (b.Lat - a.Lat) * (c.Long - a.Long) - (b.Long - a.Long) * (c.Lat - a.Lat);
        }


        bool intersect(Dot a, Dot b, Dot c, Dot d)
        {
            if (intersect_1(a.Lat, b.Lat, c.Lat, d.Lat)
                && intersect_1(a.Long, b.Long, c.Long, d.Long)
                && area(a, b, c) * area(a, b, d) <= 0
                && area(c, d, a) * area(c, d, b) <= 0)
                return true;
            else
                return false;

        }
            private bool intersect_1(double a, double b, double c, double d)
        {
            if (a > b)
            {
                double z = a;
                a = b;
                b = z;
            }
            if (c > d)
            {
                double z = c;
                c =d;
                d = z;
            }
            double max;
            double min;

            if (a >= c)
                max = a;
            else
                max = c;

            if (b <= d)
                min = b;
            else
                min = d;
            if (Math.Max(a,c) <= Math.Min(b,d))
                return true;
            else
                return false;
        }
    }
}
