using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionArthurApplication
{
    class IntegrationLogic
    {
        /// <summary>
        /// 
        /// </summary>
        private ComboJudgement combo = new ComboJudgement();
        /// <summary>
        /// 
        /// </summary>
        public IntegrationDto IntegrationDto { get { return combo.Data; } }
        /// <summary>
        /// 戦闘能力の計算結果を返す
        /// </summary>
        /// <param name="sections"></param>
        public int Calclation(List<KnightSection> sections)
        {
            // 足し上げる
            combo.Integration(sections);
            // カードの枚数によるコンボ
            CurdSize(sections);
            // 性別によるコンボ
            SexCombo(sections);
            // 勢力によるコンボ
            ForceCombo(sections);
            // 固有の勢力によるコンボ
            PrivateForceCombo(sections);
            // 型の数によるコンボ
            TypeCombo(sections);
            // 固有の組み合わせによるコンボ
            UniqueCombo(sections);

            // コンボ計算
            combo.FinalPowerCalc();


            return 0;
        }

        /// <summary>
        /// 枚数によるコンボ
        /// </summary>
        private void CurdSize(List<KnightSection> sections)
        {
            combo.Rush(sections);
        }

        /// <summary>
        /// 性別によるコンボ
        /// </summary>
        /// <param name="sections"></param>
        private void SexCombo(List<KnightSection> sections)
        {
            combo.Male(sections);
            combo.Female(sections);
        }

        /// <summary>
        /// 勢力によるコンボ
        /// </summary>
        /// <param name="sections"></param>
        private void ForceCombo(List<KnightSection> sections)
        {
            combo.ForceSword(sections);
            combo.ForceTechno(sections);
            combo.ForceMagic(sections);
            combo.ForceFairy(sections);
        }

        
        /// <summary>
        /// 固有の勢力によるコンボ
        /// </summary>
        /// <param name="sections"></param>
        private void PrivateForceCombo(List<KnightSection> sections)
        {
            combo.PrivateForceAssault(sections);
            combo.PrivateForceTechnical(sections);
            combo.PrivateForceMagic(sections);
        }

        /// <summary>
        /// 型によるコンボ
        /// </summary>
        /// <param name="sections"></param>
        private void TypeCombo(List<KnightSection> sections)
        {
            combo.SecondCombo(sections);
            combo.SupportCombo(sections);
            combo.SingularCombo(sections);
            combo.GorgeousCombo(sections);
            combo.ExplorerCombo(sections);
            combo.KannagiCombo(sections);
            combo.KuchiyoseCombo(sections);
            combo.DevilCombo(sections);
            combo.BeastCombo(sections);
            combo.ValentineCombo(sections);
            combo.MahjonggCombo(sections);
            combo.HighschoolCombo(sections);
            combo.ArlandCombo(sections);
            combo.AlchemistCombo(sections);
            combo.BravelyCombo(sections);
            combo.BridalCombo(sections);
            combo.MarriageCombo(sections);
            combo.YoungerSister(sections);
            combo.PureWhiteSong(sections);
            combo.BrideSong(sections);
            combo.Beauty(sections);
            combo.PureHeart(sections);
        }
        
        /// <summary>
        /// 固有の組み合わせによるコンボ
        /// </summary>
        private void UniqueCombo(List<KnightSection> sections)
        {
            combo.UniqueCombo(sections);
        }

    }
}
