using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KabCalclation
{
    /// <summary>
    /// カスりデータ
    /// </summary>
    class TouchData
    {
        /// <summary>
        /// 日にち
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// かすったデータ一覧
        /// </summary>
        public List<TouchPart> Sections;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TouchData()
        {
            Sections = new List<TouchPart>();
        }
    }
}
