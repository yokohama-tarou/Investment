using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace CooperationWget
{
    class OuhukuAnalyzer
    {
        /// <summary>
        /// 企業名
        /// </summary>
        private Dictionary<string, int> companyList = new Dictionary<string, int>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> Get()
        {
            return this.companyList;
        }

        /// <summary>
        /// ファイルを読込み解析を行う
        /// </summary>
        /// <param name="fileName"></param>
        public void Analysis(string fileName)
        {
            StreamReader file = new StreamReader(fileName, Encoding.GetEncoding("utf-8"));
            for (int num = 1; num < 51; num++)
            {
                // 番号を解析
                if (!FindNumber(file, num))
                {
                    Console.WriteLine(string.Format("No.{0}の番号を解析することができなかった。",num));
                    break;
                }
                // コード番号を取得
                int code;
                if (!FindCode(file, out code))
                {
                    Console.WriteLine(string.Format("No.{0}のcodeを解析することができなかった。", num));
                    break;
                }

                // 企業名を取得
                string name;
                if (!FindCompany(file, out name))
                {
                    Console.WriteLine(string.Format("No.{0}の企業名を解析することができなかった。", num));
                    break;
                }
                // 変化率を取得
                double changeRate;
                if (!FindChangeRate(file, out changeRate))
                {
                    Console.WriteLine(string.Format("No.{0}の変化率を解析することができなかった。", num));
                    break;
                }
                if (changeRate <= 0)
                {
                    companyList.Add(name, code);
                }
            }
            file.Close();
        }

        /// <summary>
        /// 渡された番号を探す
        /// </summary>
        /// <param name="file"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool FindNumber(StreamReader file, int num)
        {
            bool ret = false;
            string line;
            string noStr = string.Format("no:{0},", num.ToString());
            // ファイルを1行ずつ解析していく
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(noStr))
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// コードを取得する
        /// </summary>
        /// <param name="file"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool FindCode(StreamReader file, out int code)
        {
            bool ret = false;
            string line;
            code = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("code:"))
                    continue;
                if (!line.Contains("</a>"))
                    continue;
                int end = line.IndexOf("</a>");
                int start = 0;
                for (int i = end; i >= 0; i--)
                {
                    if (line.Substring(i, 1) == ">")
                    {
                        start = i + 1;
                        break;
                    }
                }
                string target = line.Substring(start, end - start);
                ret = int.TryParse(target, out code);
                break;
            }

            return ret;
        }

        /// <summary>
        /// 企業名を取得する
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool FindCompany(StreamReader file, out string name)
        {
            bool ret = false;
            string line;
            name = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                if(!line.Contains("name:"))
                    continue;
                if (!line.Contains("</a>"))
                    continue;
                int end = line.IndexOf("</a>");
                int start = 0;
                for (int i = end; i >= 0; i--)
                {
                    if (line.Substring(i, 1) == ">")
                    {
                        start = i+1;
                        break;
                    }
                }
                name = line.Substring(start, end - start);
                ret = true;
                break;
            }

            return ret;
        }

        /// <summary>
        /// 変化率を取得する
        /// </summary>
        /// <param name="file"></param>
        /// <param name="changeRate"></param>
        /// <returns></returns>
        private bool FindChangeRate(StreamReader file, out double changeRate)
        {
            bool ret = false;
            changeRate = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("changeP:"))
                    continue;
                int start = line.IndexOf("changeP:") + 9;
                int len = line.Length  - start - 1;
                string target = line.Substring(start, len);
                ret = double.TryParse(target, out changeRate);
                break;
            }

            return ret;
        }

    }
}
