using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finance;

namespace Exchanger
{
	class Section
	{
		public string PairName{ get; set; }

		private double BuySwap { get; set; }

        private double SellSwap { get; set; }

        public double Swap { get; set; }

		public string CountoryA { get; set; }

		public string CountoryB { get; set; }

		private double HighPosition { get; set; }

        private double LowPosition { get; set; }

		private double NowPosition { get; set; }

		public double OtokuRatio { get; set; }

        private const string fileName = "exchanger_define.ini";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pairName">セクション名</param>
        /// <param name="buy">true=買う、false=売る</param>
		public Section( string pairName, bool buy )
		{
			StringBuilder sb = new StringBuilder( 1024 * 100 );
			string dir = Directory.GetCurrentDirectory();

			this.BuySwap = IniFileHandler.GetPrivateProfileDouble( pairName, "buyswap",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            this.SellSwap = IniFileHandler.GetPrivateProfileDouble(pairName, "sellswap",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

			IniFileHandler.GetPrivateProfileString( pairName, "countoryA",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));
			CountoryA = sb.ToString();

			IniFileHandler.GetPrivateProfileString( pairName, "countoryB",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));
			CountoryB = sb.ToString();

			HighPosition = IniFileHandler.GetPrivateProfileDouble( pairName, "highposition",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            LowPosition = IniFileHandler.GetPrivateProfileDouble(pairName, "lowposition",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

			NowPosition = IniFileHandler.GetPrivateProfileDouble( pairName, "nowposition",
                "0", sb, (uint)sb.Capacity, Path.Combine(dir, fileName));

            if (buy)
            {
                this.PairName = pairName + "買い";
                OtokuRatio = NowPosition / LowPosition - 1;
                this.Swap = this.BuySwap;
            }
            else
            {
                this.PairName = pairName + "売り";
                OtokuRatio = HighPosition / NowPosition - 1;
                this.Swap = this.SellSwap;
            }

            if (OtokuRatio < 0)
                Console.WriteLine(this.PairName + ":nowpositionとhigh-lowpositionの関係がおかしい");
		}

	}
}
