using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IniFileWriter
{
    /// <summary>  </summary>
    class CompanyProperties
    {
        /// <summary> html上でのアイテム名 </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 会社名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 現在値
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// 保持データ
        /// </summary>
        public string AllData { get; set; }

    }
}
