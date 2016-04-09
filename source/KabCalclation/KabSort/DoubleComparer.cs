using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;

namespace KabCalclation.KabSort
{
    class DoubleComparer : System.Collections.IComparer,
            System.Collections.Generic.IComparer<double>
    {
        //xがyより小さいときはマイナスの数、大きいときはプラスの数、同じときは0を返す
        public int Compare(double x, double y)
        {
            return x.CompareTo(y);
        }

        public int Compare(object x, object y)
        {
            if (x is Section && y is Section)
                return Compare((Section)x, (Section)y);
            else
                return -999;
        }

        public int Compare(Section x, Section y)
        {
            //nullが最も小さいとする
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            int otokuP = 0;
            double xval = GetVal(x);
            double yval = GetVal(y);

            //配当
            if (xval > yval)
                otokuP = 1;
            else if (xval < yval)
                otokuP = -1;
            else
                otokuP = 0;

            return otokuP;
        }

        private double GetVal(Section section)
        {
            if (section.Haitou)
                return section.OtokuRatio;
            else
            {
                double val = section.OtokuRatio;
                if (section.BestPosition > section.BestPositionNeo)
                    val = (section.NowPosition / section.BestPositionNeo - 1);
                return val;
            }
        }
    }
}
