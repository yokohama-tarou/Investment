using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IniFileWriter
{
    class Program
    {



        static void Main(string[] args)
        {
            string a = Directory.GetCurrentDirectory();
            // カレントディレクトリ内のxyz拡張子のファイルを全て読み込む
            string[] xyzList = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xyz");
            foreach (string xyz in xyzList)
            {
                XyzAnalyzer analyzer = new XyzAnalyzer();
                analyzer.Analysis(xyz);
            }
        }
    }
}
