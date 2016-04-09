using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;

namespace KabCalclation
{
    /// <summary>
    /// 
    /// </summary>
    static class BestPositionLogic
    {
        /// <summary>
        /// BestPositionNeoを算出する
        /// </summary>
        /// <param name="touchList"></param>
        /// <param name="sections"></param>
        public static void Decide(List<TouchData> touchList, Section[] sections)
        {
            foreach (Section section in sections)
            {
                double touchVal = -1;
                foreach (TouchData touch in touchList)
                {
                    List<TouchPart> t = touch.Sections.Where(p => p.SectionName == section.SectionName).ToList();
                    if (t.Count() > 0)
                    {
                        touchVal = t[0].Position;
                        break;
                    }
                }
                if (touchVal >= 0)
                    section.BestPositionNeo = touchVal / 1.0515;
                else
                    section.BestPositionNeo = section.BestPosition / 1.0515;
            }
        }
    }
}
