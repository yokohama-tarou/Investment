using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finance;

namespace Finance
{
    /// <summary>
    /// INIの各セクション情報を保持するクラス
    /// </summary>
	public class Section
    {
        /// <summary>読み込むファイル名 </summary>
        const string fileName = "kab_define.ini";
        /// <summary> セクション名 </summary>
		public string SectionName{ get; set; }
        /// <summary> 銘柄コード </summary>
        public string Code { get; set; }
        /// <summary> 買いたい理想価格 </summary>
		public double BestPosition { get; set; }
        /// <summary> 現在値 </summary>
		public double NowPosition { get; set; }
        /// <summary> お得率 </summary>
		public double OtokuRatio { get; set; }
        /// <summary> 次回チェックしないといけない日付 </summary>
        public DateTime NextDateTime { get; set; }
        /// <summary> 最後に見つけた日(将来機能) </summary>
        public string LastFindTime { get; set; }
        /// <summary> 配当/優待銘柄か否か </summary>
        public bool Haitou { get { return (Unit == 0); } }
        /// <summary> 配当か否か </summary>
        public double Unit { get; set; }
        /// <summary> 変動銘柄用の値 </summary>
         public double BestPositionNeo { get; set; }

        /// <summary>
        /// 掠ったか
        /// </summary>
        public bool IsTouch { get { return (BestPosition >= NowPosition); } }

		public Section( string sectionName )
		{
            this.SectionName = sectionName;

			StringBuilder sb = new StringBuilder( 1024 * 100 );
			string dir = Directory.GetCurrentDirectory();

            IniFileHandler.GetPrivateProfileString(sectionName, "code",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));
            this.Code = sb.ToString();

            BestPosition = IniFileHandler.GetPrivateProfileDouble(sectionName, "bestposition",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            NowPosition = IniFileHandler.GetPrivateProfileDouble(sectionName, "nowposition",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            Unit = IniFileHandler.GetPrivateProfileDouble(sectionName, "unit",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            if (BestPosition > NowPosition)
                Console.WriteLine(this.Code+sectionName + "のbestpositionとnowpositionの関係がおかしい");
            OtokuRatio = (NowPosition / BestPosition - 1);

            IniFileHandler.GetPrivateProfileString(sectionName, "nextcheckdate",
                "1899/1/1", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));
            this.NextDateTime = DateTime.Parse(sb.ToString()) + new TimeSpan(9,0,0);

            IniFileHandler.GetPrivateProfileString(sectionName, "lastfindtime",
                "", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));
            this.LastFindTime = sb.ToString();

		}
    }
}
