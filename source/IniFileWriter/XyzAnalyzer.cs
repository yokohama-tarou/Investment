using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finance;

namespace IniFileWriter
{
    /// <summary>
    /// Xyz解析
    /// </summary>
    class XyzAnalyzer
    {
        const string viewItem = "viewItem";

        const string nameKey1 = "名称";
        const string nameKey2 = "\"strong\">";
        const string nameKey3 = "<";

        const string valueKey1 = "取引値";
        const string valueKey2 = "\"yjL\">";
        const string valueKey3 = "<";

        /// <summary>
        /// viewItemの取得
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string GetViewItem(int num)
        {
            string ret = "\"" + viewItem + num.ToString() + "\"";
            return ret;
        }

        /// <summary>
        /// ファイルを読込み解析を行う
        /// </summary>
        /// <param name="fileName"></param>
        public void Analysis(string fileName)
        {
            List<CompanyProperties> properties = GetProperties(fileName);
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path,"kab_define.ini");
            foreach(CompanyProperties property in properties )
            {
                property.Name = GetName(property.AllData);
                property.Value = GetValue(property.AllData);
                // IniFileに書き込む
                uint ret = Finance.IniFileHandler.WritePrivateProfileString(property.Name, "nowposition", property.Value.ToString(), path);
            }


            List<string> sections = CsvReader.GetFirstRows("kab_section.txt");
            // Iniファイルを読み込む
            List<Section> readDataSet = new List<Section>();
            foreach (string section in sections)
            {
                readDataSet.Add(new Section(section));
            }
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            foreach (Section section in readDataSet)
            {
                if (section.LastFindTime == string.Empty)
                    Finance.IniFileHandler.WritePrivateProfileString(section.SectionName, "lastfindtime", date, path);
            }
        }

        /// <summary>
        /// 取引値取得
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double GetValue(string data)
        {

            int pos = data.IndexOf(valueKey1);
            int top = data.IndexOf(valueKey2, pos) + valueKey2.Length;
            int last = data.IndexOf(valueKey3, top);
            string value = data.Substring(top, last - top);
            value = System.Text.RegularExpressions.Regex.Replace(value, ",", "");
            return double.Parse(value);
        }

        /// <summary> 名称取得 </summary>
        private string GetName(string data)
        {
            int pos = data.IndexOf(nameKey1);
            int top = data.IndexOf(nameKey2, pos) + nameKey2.Length;
            int last = data.IndexOf(nameKey3, top);
            return data.Substring(top, last - top);
        }


        /// <summary>
        /// プロパティを取得
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<CompanyProperties> GetProperties(string fileName)
        {
            List<CompanyProperties> properties = new List<CompanyProperties>();
            StreamReader file = new StreamReader(fileName, Encoding.GetEncoding("Shift_JIS"));
            for (int num = 1; num < 51; num++)
            {
                CompanyProperties property = new CompanyProperties();
                property.ItemName = GetViewItem(num);
                bool find = false; ;
                // ファイルを1行ずつ解析していく
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    // 見つけたらその後の2行をデータとして食う
                    if (line.Contains(property.ItemName))
                    {
                        find = true;
                        property.AllData += file.ReadLine();
                        property.AllData += file.ReadLine();
                    }
                }
                if (find)
                {
                    properties.Add(property);
                    file.BaseStream.Seek(0, SeekOrigin.Begin);
                }
                else
                    break;
            }

            return properties;
        }
    }
}
