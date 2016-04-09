using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionArthurApplication
{
    public class KnightComparer : System.Collections.IComparer,
            System.Collections.Generic.IComparer<double>
    {
        //xがyより小さいときはマイナスの数、大きいときはプラスの数、同じときは0を返す
        public int Compare(double x, double y)
        {
            return x.CompareTo(y);
        }

        public int Compare(object x, object y)
        {
            if (x is KnightSection && y is KnightSection)
                return Compare((KnightSection)x, (KnightSection)y);
            else
                return -999;
        }

        public int Compare(KnightSection x, KnightSection y)
        {
            //nullが最も小さいとする
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return 1;
            }
            if (y == null)
            {
                return -1;
            }

            if (x.Power > y.Power)
                return -1;
            else if (x.Power < y.Power)
                return 1;
            else
                return 0;

        }

    }
}
