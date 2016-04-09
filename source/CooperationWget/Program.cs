using System;
using System.IO;
using System.Collections.Generic;
using Finance;

namespace CooperationWget
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSVファイルからセクション名の読み込み
            List<string> sections = CsvReader.GetFirstRows("kab_section.txt");
            // Iniファイルを読み込む
            List<Section> readDataSet = new List<Section>();
            foreach (string section in sections)
            {
                readDataSet.Add(new Section(section));
            }
            // Wgetのファイルが存在することを確認する
            const string fileName = @"shikiho.jp\tk\ranking\price\ouhuku";
            if (File.Exists(fileName))
            {
                // ファイルを読み込む
                OuhukuAnalyzer analyzer = new OuhukuAnalyzer();
                analyzer.Analysis(fileName);
                Dictionary<string, int> abstruct = analyzer.Get();
                string date = DateTime.Now.ToString("yyyy/MM/dd");
                string path = System.IO.Directory.GetCurrentDirectory();
                path = System.IO.Path.Combine(path, "kab_define.ini");
                foreach (var company in abstruct)
                {
                    bool contain = false;
                    string sectionName = string.Empty;
                    foreach (string section in sections)
                    {
                        if (section.Contains(company.Key))
                        {
                            contain = true;
                            sectionName = section;
                            break;
                        }
                    }

                    // 見つからなかったものは列挙する
                    if (!contain)
                    {
                        Console.WriteLine(company.Key + " code:" + company.Value.ToString());
                    }
                    // 見つかったものはINIファイルに書き込む
                    else
                    {
                        Finance.IniFileHandler.WritePrivateProfileString(sectionName, "lastfindtime", date, path);
                    }
                }

            }
            else
            {
                Console.WriteLine("ouhukuファイルが無い");
            }
            Console.ReadLine();
        }
    }
}
