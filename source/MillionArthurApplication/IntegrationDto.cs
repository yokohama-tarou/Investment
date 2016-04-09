using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionArthurApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class IntegrationDto
    {
        /// <summary>
        /// 
        /// </summary>
        public uint Atack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint HitPoint { get; set; }
        /// <summary>
        /// コンボ名一覧
        /// </summary>
        public List<ComboDto> Combo { get; set; }
        /// <summary> コスト積算 </summary>
        public uint Cost { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IntegrationDto()
        {
            this.Combo = new List<ComboDto>();
        }
    }
}
