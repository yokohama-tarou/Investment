using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Finance;
using KabCalclation.KabSort;

namespace KabCalclation
{
	class Program
	{
		static void Main( string[] args )
		{
            // CSVファイルからセクション名の読み込み
            List<string> sections = CsvReader.GetFirstRows("kab_section.txt");
            // Iniファイルを読み込む
            List<Section> readDataSet = new List<Section>();
            foreach(string section in sections)
            {
                readDataSet.Add(new Section(section));
            }
            Section[] array = readDataSet.ToArray();
            // CSVからデータを取得
            List<TouchData> touchList = TouchPositionLogic.GetTouchList();
            // CSVファイルを書き込む
            TouchPositionLogic.WriteCsv(touchList, array);
            BestPositionLogic.Decide(touchList, array);

            DisplayDataSorter.Sort(array);

            // お得な順に一覧表示を行う
            foreach (Section section in array)
            {
                Console.WriteLine(section.SectionName + " " + section.Code +":bestposition="+ 
                    section.BestPosition + ",nowposition=" + section.NowPosition.ToString() + 
                    ",neo_position=" + ((int)section.BestPositionNeo).ToString());
                Console.WriteLine((section.OtokuRatio*100).ToString("f4") + " , " + 
                    ((section.NowPosition / section.BestPositionNeo - 1)*100).ToString("f4"));
            }
            // 日時を表示
            foreach (Section section in readDataSet)
            {
                if (section.NextDateTime < DateTime.Now)
                {
                    Console.WriteLine(section.SectionName + " " + section.Code + 
                        "の日時を確認：" + section.NextDateTime.ToString("yyyy/MM/dd"));
                }
            }
			Console.ReadLine();
		}
	}
}
