using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finance;

namespace MillionArthurApplication
{
    /// <summary>
    /// 勢力
    /// </summary>
    public enum Force
    {
        /// <summary>
        /// 剣
        /// </summary>
        SWORD = 0,
        /// <summary>
        /// テクノ
        /// </summary>
        TECHNO = 1,
        /// <summary>
        /// 魔法
        /// </summary>
        MAGIC = 2,
        /// <summary>
        /// 妖精
        /// </summary>
        FAIRY = 3
    }

    /// <summary>
    /// 勢力毎のフォース
    /// </summary>
    public enum PrivateForce
    {
        /// <summary>
        /// アサルト
        /// </summary>
        ASSAULT=0,
        /// <summary>
        /// テクノカル
        /// </summary>
        TECHNICAL=1,
        /// <summary>
        /// 魔法
        /// </summary>
        MAGIC=2
    }

    /// <summary>
    /// 性別
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男
        /// </summary>
        MALE=0,
        /// <summary>
        /// 女
        /// </summary>
        FEMALE=1,
        /// <summary>
        /// おかま
        /// </summary>
        SHEMALE=2
    }

    /// <summary>
    /// 騎士INIファイルを読み込む
    /// </summary>
    public class KnightSection
    {
        /// <summary> 騎士名 </summary>
        public string KnightName { get; set; }
        /// <summary> 攻撃力 </summary>
        public uint Attack { get; set; }
        /// <summary> HP </summary>
        public uint HitPoint { get; set; }
        /// <summary> 勢力 </summary>
        public Force Force { get; set; }
        /// <summary> 勢力毎のフォース </summary>
        public PrivateForce PrivateForce { get; set; }
        /// <summary> 性別 </summary>
        public Sex Sex { get; set; }
        /// <summary> コスト </summary>
        public uint Cost { get; set; }
        /// <summary> コスパ </summary>
        public double Cospa { get; set; }
        /// <summary>TOTALな力</summary>
        public uint Power { get { return this.Attack + this.HitPoint; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="knightName"></param>
        public KnightSection(string knightName)
        {
            Initialize(Directory.GetCurrentDirectory(), knightName);
        }
            
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="knightName"></param>
        public KnightSection(string dir,string knightName)
		{
            Initialize(dir,knightName);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="knightName"></param>
        private void Initialize(string dir, string knightName)
        {
            this.KnightName = knightName;

            StringBuilder sb = new StringBuilder(1024 * 100);

            this.Attack = IniFileHandler.GetPrivateProfileInt(knightName, "attack",
                0, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            this.HitPoint = IniFileHandler.GetPrivateProfileInt(knightName, "hitpoint",
                0, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            this.Force = (Force)IniFileHandler.GetPrivateProfileInt(knightName, "force",
                0, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            this.PrivateForce = (PrivateForce)IniFileHandler.GetPrivateProfileInt(knightName, "privateforce",
                0, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            this.Sex = (Sex)IniFileHandler.GetPrivateProfileInt(knightName, "sex",
                0, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            // 読込失敗したらコスト30ってことで
            this.Cost = IniFileHandler.GetPrivateProfileInt(knightName, "cost",
                30, Path.Combine(dir, Properties.Resources.INI_FILE_NAME));

            // HitPointの補正
            if (this.Force == MillionArthurApplication.Force.TECHNO)
                this.HitPoint = (uint)((double)this.HitPoint * 1.05);

            // コスパの算出
            Cospa = (double)(this.HitPoint + this.Attack) / (double)Cost;
            if (Cost == 30 || Cost == 0)
            {
                Cospa = 0;
            }
        }


    }
}
