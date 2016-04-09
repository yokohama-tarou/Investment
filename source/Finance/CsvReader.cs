using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Finance
{
    /// <summary>
    /// CSVファイルを読み込むクラス
    /// </summary>
    public static class CsvReader
    {
        /// <summary>
        /// CSVファイルの一列目だけリストにして返す
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<string> GetFirstRows(string fileName)
        {
            string dir = Directory.GetCurrentDirectory();
            return FirstRows(dir, fileName);
        }

        /// <summary>
        /// CSVファイルの一列目だけリストにして返す
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<string> GetFirstRows(string dir, string fileName)
        {
            return FirstRows(dir, fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static List<string> FirstRows(string dir, string fileName)
        {
            string csvName = dir;
            csvName = Path.Combine(csvName, fileName);
            TextFieldParser parser = new TextFieldParser(csvName,
            System.Text.Encoding.GetEncoding("Shift_JIS"));

            List<string> sections = new List<string>();
            using (parser)
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");


                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields(); // 1行読み込み
                    sections.Add(row[0]);
                }
            }
            return sections; 
        }


        /// <summary>
        /// CSVファイルを返す
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<List<string>> GetAllRows(string fileName)
        {
            List<List<string>> sections = new List<List<string>>();

            string csvName = Directory.GetCurrentDirectory();
            csvName = Path.Combine(csvName, fileName);
            if (File.Exists(csvName))
            {
                TextFieldParser parser = new TextFieldParser(csvName,
                System.Text.Encoding.GetEncoding("Shift_JIS"));

                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");


                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        sections.Add(row.ToList());

                    }
                }
            }
            return sections;
        }

    }
}
