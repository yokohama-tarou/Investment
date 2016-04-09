using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finance;

namespace MillionArthurApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 3;
            bool first = false;
            bool cost_cut = false;
            bool million = false;
            // モード決定
            if(args.Count() > 0)
                int.TryParse(args[0], out m);
            if (args.Count() > 1)
                if (args[1] == "first")
                    first = true;
            if (args.Count() > 2)
            {
                if (args[2] == "cost_cut")
                {
                    cost_cut = true;
                }
                if (args[2] == "million")
                {
                    million = true;
                    m -= 3;
                }
            }


            // 前回結果が無ければ作成
            FileUtility.InitializeBeforeFile();

            DateTime start = DateTime.Now;
            // Iniファイルを読み込む
            List<KnightSection> readDataSet = FileUtility.GetSectionData(System.IO.Directory.GetCurrentDirectory(), m);

            //TODO 機動時パラメータから差分騎士を把握
            //List<KnightSection> difference = GetDifferenceKnight(readDataSet,args);


            // 昇順ソート＆1000万以下間引き処理
            List<KnightSection> array = GetN(readDataSet, m);

            // 組み合わせの作成
            List<IList<KnightSection>> combi;
            if (first)
                combi = new Combinations<KnightSection>(array, m).GetCombinations();
            else
            {
                // 差分騎士の把握②
                List<string> difference = FileUtility.LoadDifferenceKnight(readDataSet, m);
                Console.WriteLine("差分騎士の羅列");
                foreach (string name in difference)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
                int[] result = MabikiIndex(array, difference);
                combi = new MabikiCombinations<KnightSection>(array, m, result).GetCombinations();
            }

            // 全組み合わせにアーサーsを加える
            if (million)
            {
                int i = 0;
                int combi_count = combi.Count();
                List<KnightSection> arther = new List<KnightSection>();
                arther.AddRange(readDataSet.Where(s => s.KnightName == "アーサー -剣術の城"));
                arther.AddRange(readDataSet.Where(s => s.KnightName == "アーサー -技巧の場"));
                arther.AddRange(readDataSet.Where(s => s.KnightName == "アーサー -魔法の派"));
                for (i = 0; i < combi_count; i++)
                {
                    List<KnightSection> a = combi[i].ToList();
                    a.Add(arther[0]);
                    a.Add(arther[1]);
                    a.Add(arther[2]);
                    combi[i] = a;

                }
            }

            // 前回最強結果の取得
            IntegrationDto no1 = FileUtility.GetBeforeNo1(m);
            List<KnightSection> no1Sections = FileUtility.GetBeforeNo1Section(m);
            IntegrationLogic logic = new IntegrationLogic();
            for (int i = 0; i < combi.Count(); i++ )
            {
                logic.Calclation(combi[i].ToList());
                //if ((no1.Atack + no1.HitPoint) / no1.Cost < (logic.IntegrationDto.Atack + logic.IntegrationDto.HitPoint) / logic.IntegrationDto.Cost)
                if (Compare(no1,logic.IntegrationDto,cost_cut))
                {
                    no1.HitPoint = logic.IntegrationDto.HitPoint;
                    no1.Atack = logic.IntegrationDto.Atack;
                    no1.Combo = new List<ComboDto>(logic.IntegrationDto.Combo);
                    no1.Cost = logic.IntegrationDto.Cost;
                    no1Sections = combi[i].ToList();
                }
            }
            foreach (KnightSection section in no1Sections)
            {
                Console.WriteLine(section.KnightName);
            }
            foreach (ComboDto section in no1.Combo)
            {
                Console.WriteLine(section.Name);
            }
            Console.WriteLine((((double)no1.Atack * (double)no1.HitPoint) / (double)no1.Cost).ToString());
            TimeSpan delta = DateTime.Now - start;

            Console.WriteLine("総配列数：" + combi.Count().ToString());
            Console.WriteLine("使用時間："+delta.TotalSeconds.ToString());

            // アプリ終了前操作
            // 現在のSECTION、INIファイルを別名保存する
            FileUtility.SaveBeforeFile(m);
            FileUtility.SaveXmlConfig(no1,no1Sections,m);

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int[] MabikiIndex(List<KnightSection> array, List<string> difference)
        {
            List<int> result = new List<int>();
            for(int i = 0; i < difference.Count(); i++)
            {
                for (int j = 0; j < array.Count(); j++)
                {
                    if (array[j].KnightName == difference[i])
                    {
                        result.Add(j);
                        break;
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="no1"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool Compare(IntegrationDto no1, IntegrationDto b, bool cost_cut)
        {
            double aval = 0;
            double bval = 0;
            if (!cost_cut)
            {
                if (no1.Cost != 0)
                    aval = ((double)no1.Atack * (double)no1.HitPoint) / (double)no1.Cost;
                if (b.Cost != 0)
                    bval = ((double)b.Atack * (double)b.HitPoint) / (double)b.Cost;

                return (aval < bval);
            }
            else
            {
                if (no1.Cost != 0)
                    aval = ((double)no1.Atack * (double)no1.HitPoint);
                if (b.Cost != 0)
                    bval = ((double)b.Atack * (double)b.HitPoint);

                return (aval < bval); 
            }
        }

        /// <summary>
        /// 対象の配列内から差分岐しを抽出
        /// </summary>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static List<KnightSection> GetDifferenceKnight(List<KnightSection> target, string[] args)
        {
            List<KnightSection> difference = new List<KnightSection>();
            for (int i = 1; i < args.Count(); i++)
            {
                difference.AddRange(target.Where(a => a.KnightName == args[i]));
            }
            return difference;
        }

        /// <summary>
        /// 昇順ソート後、間引きして返す
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static List<KnightSection> GetN(List<KnightSection> sections, int m)
        {
            int n = sections.Count();
            for (int i = m; i < sections.Count(); i++)
            {
                if (nCm(i, m) > 10000000)
                {
                    n = i - 1;
                    break;
                }
            }

            KnightSection[] array = sections.ToArray();
            Array.Sort(array, new KnightComparer());
            // 返す前に書き出しておく
            StreamWriter sw = new StreamWriter("strongest" + m.ToString() + ".txt");
            for (int i = 0; i < array.Length;i++ )
                sw.WriteLine(array[i].KnightName);
            sw.Close();

            return array.ToList().GetRange(0,n);
        }


        // Copyright (C) 2013 sz-x638 All rights reserved.
        // http://zweihander638.blog.fc2.com
        public static int nCm(int n, int m)
        {
            if (m == 0) return 1;
            if (n == 0) return 0;
            return n * nCm(n - 1, m - 1) / m;
        }
    }
}
