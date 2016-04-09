using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;

namespace Exchanger
{
	class Program
	{
		static void Main( string[] args )
		{
			try
            {
                // CSVファイルからセクション名の読み込み
                List<string> sections = CsvReader.GetFirstRows("exchanger_section.txt");
                List<string> removes = CsvReader.GetFirstRows("remove.txt");
                // Iniファイルを読み込む
                List<Section> orignals = new List<Section>();
                foreach (string section in sections)
                {
                    bool cont = false;
                    // 削除対象か？
                    foreach (string remove in removes)
                    {
                        if (section.IndexOf(remove) >= 0)
                        {
                            cont = true;
                            break;
                        }
                    }
                    if (cont)
                        continue;
                    orignals.Add(new Section(section, true));
                    orignals.Add(new Section(section, false));
                }
                // 10676通り→194580通り
				Combinations<Section> combinations = new Combinations<Section>( orignals.ToArray(), 4 );
				IEnumerator<IList<Section>> combination = combinations.GetEnumerator();

				double otoku = 999;
				string target = string.Empty;
				Dictionary<string, int> map = new Dictionary<string, int>();
				foreach ( Section[] oneCom in combinations )
				{
					map.Clear();
					double totalOtoku = 0;
                    double totalswap = 0;
					for ( int i = 0; i < 4; i++ )
					{
						//A
						if ( map.ContainsKey( oneCom[i].CountoryA ) )
							break;
						else
							map.Add( oneCom[i].CountoryA, i );
						// B
						if ( map.ContainsKey( oneCom[i].CountoryB ) )
							break;
						else
							map.Add( oneCom[i].CountoryB, i );

						totalOtoku += oneCom[i].OtokuRatio;
                        totalswap += oneCom[i].Swap;
						if ( i == 3 )
						{
                            // swapポイントがある程度ないと不採用
                            if (totalswap < 10)
                                break;
                            Console.WriteLine("有効ペア" + oneCom[0].PairName + "," + oneCom[1].PairName + "," + oneCom[2].PairName + "," + oneCom[3].PairName + ":" + totalOtoku.ToString());
							if ( otoku > totalOtoku )
							{
								otoku = totalOtoku;
                                target = "Answer=" + oneCom[0].PairName + "," + oneCom[1].PairName + "," + oneCom[2].PairName + "," + oneCom[3].PairName + ":" + totalOtoku.ToString();
							}
						}
					}
				}

				Console.WriteLine( target );
			}
			catch
			{ 
			}
			Console.ReadLine();
		}
	}
}
