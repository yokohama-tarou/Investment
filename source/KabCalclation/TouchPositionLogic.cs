using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using System.IO;

namespace KabCalclation
{
    static class TouchPositionLogic
    {
        public static List<TouchData> GetTouchList()
        {
            List<List<string>> csv = CsvReader.GetAllRows("touch.csv");
            // データを作る
            List<TouchData> touchList = CreateTouchList(csv);
            // 15日以上前のデータは消す
            DateTime border = DateTime.Now - new TimeSpan(15, 0, 0, 0);
            return touchList.Where(touch => touch.Date > border).ToList();
        }

        /// <summary>
        /// かすりデータ一覧を作って返す
        /// </summary>
        /// <param name="csv"></param>
        /// <returns></returns>
        private static List<TouchData> CreateTouchList(List<List<string>> csv)
        {
            List<TouchData> result = new List<TouchData>();
            foreach (List<string> row in csv)
            {
                if (row.Count() == 0)
                    continue;
                TouchData touch = new TouchData();
                touch.Date = DateTime.Parse(row[0]);
                for(int i = 1; i < row.Count(); i+=2)
                {
                    TouchPart part = new TouchPart();
                    part.SectionName = row[i];
                    part.Position = Convert.ToDouble(row[i + 1]);
                    touch.Sections.Add(part);
                }
                //// 今日のデータは含めない
                //if(touch.Date!=DateTime.Now.Date)
                    result.Add(touch);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchList"></param>
        /// <param name="sections"></param>
        public static void WriteCsv(List<TouchData> touchList, Section[] sections)
        {
            TouchData touch = GetTodaysTouchData(sections);
            if (touch.Sections.Count() > 0)
            {
                if (touchList.Count>0)
                {
                    TouchData target = touchList.Last();
                    // 同じ日のデータがすでに含まれる
                    if (touch.Date == target.Date)
                    {
                        // bestpositionで更新する
                        UpdateBestPosition(sections, target);

                        foreach (TouchPart part in target.Sections)
                        {
                            List<TouchPart> a = touch.Sections.Where(p => p.SectionName == part.SectionName).ToList();
                            if (a.Count() > 0)
                            {
                                a[0].Position = part.Position;
                            }
                            else
                            {
                                touch.Sections.Add(part);
                            }
                        }
                    }
                }
                touchList.Add(touch);
            }
            ConvertDataTableToCsv(touchList, "touch.csv");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        private static TouchData GetTodaysTouchData(Section[] sections)
        {
            TouchData touch = new TouchData();
            touch.Date = DateTime.Now.Date;
            foreach (Section section in sections)
            {
                if (section.IsTouch)
                {
                    TouchPart part = new TouchPart();
                    part.SectionName = section.SectionName;
                    part.Position = section.NowPosition;
                    if (part.Position > section.BestPosition)
                        part.Position = section.BestPosition;
                    touch.Sections.Add(part);
                }
            }

            return touch;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="target"></param>
        private static void UpdateBestPosition(Section[] sections, TouchData target)
        {
            foreach (TouchPart tp in target.Sections)
            {
                List<Section> section = sections.Where(p => p.SectionName == tp.SectionName).ToList();
                if (section.Count() > 0)
                {
                    if (section[0].BestPosition < tp.Position)
                        tp.Position = section[0].BestPosition;
                }
            }
        }


        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">CSVに変換するDataTable</param>
        /// <param name="csvPath">保存先のCSVファイルのパス</param>
        private static void ConvertDataTableToCsv(
            List<TouchData> dt, string csvPath)
        {
            string csvName = Directory.GetCurrentDirectory();
            csvName = Path.Combine(csvName, csvPath);
            //CSVファイルに書き込むときに使うEncoding
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("Shift_JIS");

            //書き込むファイルを開く
            System.IO.StreamWriter sr =
                new System.IO.StreamWriter(csvName, false, enc);

            
            //レコードを書き込む
            foreach (TouchData row in dt)
            {
                sr.Write(row.Date.ToString("yyyy/MM/dd"));
                for (int i = 0; i < row.Sections.Count; i++)
                {
                    sr.Write(',');
                    //フィールドの取得
                    TouchPart field = row.Sections[i];
                    //"で囲む
                    string sectionName = EncloseDoubleQuotesIfNeed(field.SectionName);
                    //フィールドを書き込む
                    sr.Write(sectionName);
                    sr.Write(',');
                    sr.Write(field.Position.ToString());
                }
                //改行する
                sr.Write("\r\n");
            }

            //閉じる
            sr.Close();
        }

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        private static bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }
    }
}
