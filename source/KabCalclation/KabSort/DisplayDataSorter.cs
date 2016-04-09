using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;

namespace KabCalclation.KabSort
{
    /// <summary>
    /// 最後にディスプレイ表示するデータをソートする
    /// </summary>
    static class DisplayDataSorter
    {
        public static void Sort(Section[] array)
        {

            // お得度で並び替えを行う
            Array.Sort(array, new DoubleComparer());
        }
    }
}
