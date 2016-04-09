using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionArthurApplication
{
    public class ComboJudgement
    {
        /// <summary>
        /// コンボ判定用オブジェクト
        /// </summary>
        private List<ComboDto> comboList;
        /// <summary>特定の組み合わせのコンボ</summary>
        private Dictionary<string, string[]> identifications;
        /// <summary> </summary>
        public IntegrationDto Data{get;set;}
        /// <summary> 固有名 </summary>
        private Dictionary<string, string[]> uniqueCombination;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ComboJudgement()
        {
            Data = new IntegrationDto();
            comboList = new List<ComboDto>();
            identifications = new Dictionary<string, string[]>();

            // カードの枚数によるコンボ
            comboList.Add(new ComboDto { Name = "ラッシュコンボ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ラッシュコンボ・ライズ", HpUp = 20, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ラッシュコンボ・クラウン", HpUp = 30, AtkUp = 0 });
            // 性別によるコンボ
            comboList.Add(new ComboDto { Name = "プリンセスコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "プリンセスコンボ・ライズ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "プリンセスコンボ・クラウン", HpUp = 12, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "プリンスコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "プリンスコンボ・ライズ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "プリンスコンボ・クラウン", HpUp = 12, AtkUp = 0 });
            // 勢力によるコンボ
            comboList.Add(new ComboDto { Name = "アサルトコンボ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アサルトコンボ・ライズ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アサルトコンボ・クラウン", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "テクニカルコンボ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "テクニカルコンボ・ライズ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "テクニカルコンボ・クラウン", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マジックコンボ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マジックコンボ・ライズ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マジックコンボ・クラウン", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "フェアリーコンボ・ライト", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "フェアリーコンボ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "フェアリーコンボ・ライズ", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "フェアリーコンボ・クラウン", HpUp = 45, AtkUp = 0 });
            // フォースによるコンボ
            comboList.Add(new ComboDto { Name = "アサルトフォース", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "アサルトフォース・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "アサルトフォース・クラウン", HpUp = 0, AtkUp = 11 });
            comboList.Add(new ComboDto { Name = "テクニカルフォース", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "テクニカルフォース・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "テクニカルフォース・クラウン", HpUp = 0, AtkUp = 11 });
            comboList.Add(new ComboDto { Name = "マジックフォース", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "マジックフォース・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "マジックフォース・クラウン", HpUp = 0, AtkUp = 11 });
            // 型の組み合わせによるコンボ
            comboList.Add(new ComboDto { Name = "ナイトコンボ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ナイトコンボ・ライズ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ナイトコンボ・クラウン", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "サポートコンボ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "サポートコンボ・ライズ", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "サポートコンボ・クラウン", HpUp = 25, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "レジェンドコンボ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "レジェンドコンボ・ライズ", HpUp = 17, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "レジェンドコンボ・クラウン", HpUp = 27, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ジュエリーコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ジュエリーコンボ・ライズ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "エクスプローラー", HpUp = 4, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "エクスプローラー・ライズ", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "エクスプローラー・クラウン", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "巫《かんなぎ》コンボ", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "巫《かんなぎ》コンボ・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "巫《かんなぎ》コンボ・クラウン", HpUp = 0, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "口寄《くちよせ》コンボ", HpUp = 4, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "口寄《くちよせ》コンボ・ライズ", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "口寄《くちよせ》コンボ・クラウン", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "デビルコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ビーストコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ビーストコンボ・ライズ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "バレンタインコンボ", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "バレンタインコンボ・ライズ", HpUp = 0, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "バレンタインコンボ・クラウン", HpUp = 0, AtkUp = 15 });
            comboList.Add(new ComboDto { Name = "麻雀コンボ", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "麻雀コンボ・ライズ", HpUp = 12, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "麻雀コンボ・クラウン", HpUp = 18, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ハイスクールコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ハイスクールコンボ・ライズ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ハイスクールコンボ・クラウン", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アーランドコンボ", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アーランドコンボ・ライズ", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アーランドコンボ・クラウン", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "錬金術コンボ", HpUp = 5, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "錬金術コンボ・ライズ", HpUp = 10, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "錬金術コンボ・クラウン", HpUp = 15, AtkUp = 15 });
            comboList.Add(new ComboDto { Name = "ブレイブリーコンボ", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "ブレイブリーコンボ・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "ブレイブリーコンボ・クラウン", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "ブライダルコンボ", HpUp = 3, AtkUp = 3 });
            comboList.Add(new ComboDto { Name = "ブライダルコンボ・ライズ", HpUp = 5, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "ブライダルコンボ・クラウン", HpUp = 8, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "マリッジコンボ", HpUp = 3, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マリッジコンボ・ライズ", HpUp = 7, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マリッジコンボ・クラウン", HpUp = 18, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マリッジコンボ・ファイナル", HpUp = 30, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ヤンガーシスター", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "ヤンガーシスター・ライズ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "ヤンガーシスター・クラウン", HpUp = 0, AtkUp = 12 });


            uniqueCombination = new Dictionary<string, string[]>();
            uniqueCombination.Add("12月の花嫁", new string[] { "第二型セイント", "純白型セイント" });
            uniqueCombination.Add("アークブラスト", new string[] { "第二型ランソール", "第二型ベイリン" });
            uniqueCombination.Add("アーサーの嫁入り？", new string[] { "華嫁型アーサー -技巧の場", "華嫁型アーサー -魔法の派" });
            uniqueCombination.Add("アームドセレクション", new string[] { "第一型ガラハッド", "第二型ベイリン", "第二型メレアガンス" });
            uniqueCombination.Add("アーランドの錬金術士", new string[] { "アーランド型ロロナ", "アーランド型トトリ", "アーランド型メルル" });
            uniqueCombination.Add("アウターワールド", new string[] { "外敵型バン", "外敵型ボールス" });
            uniqueCombination.Add("アブソリュートルーラー", new string[] { "第一型ガウェイン", "第二型ユーウェイン", "第二型マロース" });
            uniqueCombination.Add("新たな目覚め？？", new string[] { "干支型アーサー -魔法の派", "アーサー -魔法の派" });
            uniqueCombination.Add("アンノウンフォース", new string[] { "第二型ベイリン", "第二型ベイラン" });
            uniqueCombination.Add("アンラッキーナンバー", new string[] { "姫憂型アンケセナーメン", "姫憂型 輝夜", "姫憂型 茶々" });
            uniqueCombination.Add("インターセクトリサーチ", new string[] { "絢爛型ラピス", "絢爛型ターコイズ" });
            uniqueCombination.Add("インビンシブル", new string[] { "第二型ガーロン", "第二型ベイリン" });
            uniqueCombination.Add("インペリアルゴールド", new string[] { "支援型シトリンク", "絢爛型オニキス", "第二型パギー" });
            uniqueCombination.Add("ウェイクアップオアスリープ", new string[] { "支援型キャンディ", "支援型フワニータ" });
            uniqueCombination.Add("エターナルギア", new string[] { "第二型ガレス", "支援型リネット", "支援型リオネス" });
            uniqueCombination.Add("エレメントリンク(1)", new string[] { "第一型ランスロット", "鹵獲型魔女のエレイン", "第一型ガラハッド" });
            uniqueCombination.Add("エレメントリンク(2)", new string[] { "鹵獲型モーガン", "第二型ユーウェイン", "試作型ユリエンス" });
            uniqueCombination.Add("エレメントリンク(3)", new string[] { "王位型コンスタンティン", "第二型カドール" });
            uniqueCombination.Add("エレメントリンク(4)", new string[] { "第一型ランスロット", "外敵型バン" });
            uniqueCombination.Add("エレメントリンク(5)", new string[] { "第二型ガレス", "試作型ロット" });
            uniqueCombination.Add("エレメントリンク(6)", new string[] { "第二型トール", "第二型ペリノア" });
            uniqueCombination.Add("オーディエンス", new string[] { "幻獣型エドナ", "幻獣型ミクトラン", "第二型チェリーニ" });
            uniqueCombination.Add("オールブルーム", new string[] { "支援型ローゾフィア", "支援型パンジー" });
            uniqueCombination.Add("お色直し", new string[] { "アーサー -魔法の派", "実在型アーサー -魔法の派" });
            uniqueCombination.Add("おさなづま", new string[] { "純白型クラッキー", "純白型セイント" });
            uniqueCombination.Add("おしかけ女房", new string[] { "純白型ビスクラヴレット", "純白型リトルグレイ" });
            uniqueCombination.Add("オバケは苦手！？", new string[] { "錬金術型パメラ", "錬金術型フアナ" });
            uniqueCombination.Add("女の子と勘違い？", new string[] { "華恋型ヴィヴィアン", "華恋型アーサー -魔法の派-" });
            uniqueCombination.Add("華恋な武闘派", new string[] { "華恋型キコ", "華恋型ヴィヴィアン" });
            uniqueCombination.Add("華恋な肉食系", new string[] { "華恋型シャーリー", "華恋型ヴィヴィアン" });
            uniqueCombination.Add("クイーンズプレステージ", new string[] { "支援型クレア", "第二型ボールスジュニア" });
            uniqueCombination.Add("グランドシールド", new string[] { "第一型ランスロット", "統御型グィネヴィア" });
            uniqueCombination.Add("クレイジーホワイト", new string[] { "第二型トリストラム", "第二型マルク" });
            uniqueCombination.Add("サーヴァント(1)", new string[] { "第一型ガウェイン", "特殊型グリンゴレット" });
            uniqueCombination.Add("サーヴァント(2)", new string[] { "第二型ユーウェイン", "特殊型ユーウェインのライオン" });
            uniqueCombination.Add("シェアードセンス", new string[] { "絢爛型クウォーツ", "支援型キャンティ" });
            uniqueCombination.Add("ジェネレーションロード", new string[] { "復元型ウーサー", "試作型ヴォーティガーン", "特殊型アンブロシウス" });
            uniqueCombination.Add("じゃあライオンはもらっていきますね", new string[] { "純白型ユーウェインのライオン", "第二型アメルトギア" });
            uniqueCombination.Add("スイートキャット", new string[] { "鹵獲型モルゴース", "鹵獲型魔女のエレイン", "鹵獲型モーガン" });
            uniqueCombination.Add("スタートアップ", new string[] { "第二型カルディス", "第二型ボールスジュニア", "第二型バーナード", "支援型オルウェン" });
            uniqueCombination.Add("ストームレイン", new string[] { "支援型リュネット", "支援型ローディーネ", "第二型ユーウェイン" });
            uniqueCombination.Add("ストレイトライナー", new string[] { "第二型トリストラム", "第二型ラモラック" });
            uniqueCombination.Add("聖杯の祝福・アーサー", new string[] { "アーサー -技巧の場", "支援型聖杯のエレイン" });
            uniqueCombination.Add("聖杯の祝福・ガウェイン", new string[] { "支援型聖杯のエレイン", "第一型ガウェイン" });
            uniqueCombination.Add("セカンドエフェクト", new string[] { "姫憂型アンケセナーメン", "姫憂型 輝夜", "姫憂型ナイチンゲール" });
            uniqueCombination.Add("ソウルトレード", new string[] { "第二型ペリドッド", "支援型カーネリアン", "絢爛型ガーネット" });
            uniqueCombination.Add("その鎧、ふざけてるだろ", new string[] { "実在型アーサー -技巧の場 実写ver", "第一型ガウェイン" });
            uniqueCombination.Add("ソリッドファイター", new string[] { "第二型トール", "第二型バグデマグス" });
            uniqueCombination.Add("ダートガールズ", new string[] { "特異型ジャンヌダルク", "特異型甲斐姫", "特異型ナージェジタ" });
            uniqueCombination.Add("タクティクスアシスト", new string[] { "第二型トリストラム", "第二型カエルダン" });
            uniqueCombination.Add("ダメージオブスネイク", new string[] { "第二型イアチャオ", "第二型アナコンダ" });
            uniqueCombination.Add("ツーペア", new string[] { "外敵型ボールス", "支援型エヴェイン" });
            uniqueCombination.Add("ディスコンテントエクスプロード", new string[] { "外敵型バン", "支援型アグラヴァディン" });
            uniqueCombination.Add("ディスティニーリンク", new string[] { "試作型ヴォーティガーン", "特殊型ロウエナ" });
            uniqueCombination.Add("トップトレーナー1", new string[] { "アーサー -剣術の城", "教練型ケイ" });
            uniqueCombination.Add("トップトレーナー2", new string[] { "アーサー -技巧の場", "教練型ケイ" });
            uniqueCombination.Add("トップトレーナー3", new string[] { "アーサー -魔法の派", "教練型ケイ" });
            uniqueCombination.Add("トラストミー", new string[] { "第二型ディナダン", "第二型ブレウノール" });
            uniqueCombination.Add("トリプルウェポン", new string[] { "特異型ヘルヴォール", "特異型ディートリヒ", "特異型ゲオルギウス" });
            uniqueCombination.Add("ハート&エンジェル", new string[] { "支援型金髪のイゾルデ", "支援型ブランクウェイン" });
            uniqueCombination.Add("パートナー・アサルト", new string[] { "アーサー -剣術の城", "複製型フェイ" });
            uniqueCombination.Add("パートナー・テクニカル", new string[] { "アーサー -技巧の場", "複製型リーフェ" });
            uniqueCombination.Add("パートナー・マジック", new string[] { "アーサー -魔法の派", "複製型エル" });
            uniqueCombination.Add("白鳥達の宴", new string[] { "支援型タルヒ", "支援型ロータス", "支援型アルティマ" });
            uniqueCombination.Add("白鳥達の湖1", new string[] { "支援型タルヒ", "支援型ロータス" });
            uniqueCombination.Add("白鳥達の湖2", new string[] { "支援型タルヒ", "支援型アルティマ" });
            uniqueCombination.Add("白鳥達の湖3", new string[] { "支援型アルティマ", "支援型ロータス" });
            uniqueCombination.Add("バトルスピナー", new string[] { "支援型ティニア", "支援型フワニータ" });
            uniqueCombination.Add("ビッグガーディアン", new string[] { "第二型コルグリヴァンス", "第二型ボールスジュニア" });
            uniqueCombination.Add("ビューティフルカラー", new string[] { "特異型スノーホワイト", "特異型クレオパトラ", "特異型サロメ" });
            uniqueCombination.Add("ブロークンハート", new string[] { "第二型ルーカン", "制御型ベディヴィア" });
            uniqueCombination.Add("ホムンクルス", new string[] { "アーランド型ホム(男)", "アーランド型ホム(女)" });
            uniqueCombination.Add("マネーゲーム", new string[] { "特異型アントアネット", "特異型ルクレツィア" });
            uniqueCombination.Add("ミリオンソード", new string[] { "アーサー -剣術の城", "アーサー -技巧の場", "アーサー -魔法の派" });
            uniqueCombination.Add("メイクアップ", new string[] { "支援型ユーニア", "第二型フランシース" });
            uniqueCombination.Add("もふもふ嫁", new string[] { "華嫁型フワニータ", "純白型ユーウェインのライオン" });
            uniqueCombination.Add("ラテントエナジー", new string[] { "絢爛型マリン", "支援型メルト" });
            uniqueCombination.Add("リアリティディスクローズ", new string[] { "第二型ヘリン", "第二型ボールスジュニア" });
            uniqueCombination.Add("リヴェンジャー(1)", new string[] { "第一型ランスロット", "第一型ガウェイン", "第二型アイアンサイド" });
            uniqueCombination.Add("リヴェンジャー(2)", new string[] { "支援型金髪のイゾルデ", "第二型マロース" });
            uniqueCombination.Add("リバースグラップラー", new string[] { "第一型ガウェイン", "第二型ペリアス" });
            uniqueCombination.Add("リファインメントタスク", new string[] { "特殊型ユーウェインのライオン", "教練型ケイ" });
            uniqueCombination.Add("レイオブスピリット", new string[] { "絢爛型サファイヤ", "絢爛型レクレアス", "絢爛型ルビー" });
            uniqueCombination.Add("レイルブレイブ", new string[] { "第二型オンズレイク", "第二型ダーマス" });
            uniqueCombination.Add("ロイヤルロード", new string[] { "復元型ウーサー", "特殊型ゴルロイス" });
            uniqueCombination.Add("ワイフイズドラゴン", new string[] { "第二型ムーランティ", "支援型ソウデロア" });
            uniqueCombination.Add("ワイルドペア", new string[] { "特殊型グリンゴレット", "特殊型ユーウェインのライオン" });
            uniqueCombination.Add("法王と三銃士", new string[] { "ブレイブリー型アニエス", "ブレイブリー型三銃士" });
            uniqueCombination.Add("囚われの法王", new string[] { "ブレイブリー型アニエス" });
            uniqueCombination.Add("かつての仲間たち", new string[] { "ブレイブリー型ティズ", "ブレイブリー型イデア", "ブレイブリー型アニエス" });
            uniqueCombination.Add("一方的なぞっこんラブ", new string[] { "ブレイブリー型パネットーネ", "ブレイブリー型エイミー" });
            uniqueCombination.Add("ねこはいいにゃ", new string[] { "ブレイブリー型ミネット＆謎の老人" });
            uniqueCombination.Add("かっかっか･･･！", new string[] { "ブレイブリー型ミネット＆謎の老人" });
            uniqueCombination.Add("ショウタ～イム", new string[] { "ブレイブリー型マグノリア" });
            uniqueCombination.Add("拡散性 閏月戈", new string[] { "支援型マグビー", "第二型メンスロイ" });
            uniqueCombination.Add("雨と風の輪舞曲", new string[] { "第二型メンスロイ", "ファゾリン" });
            uniqueCombination.Add("森と風の幻想曲", new string[] { "第二型メンスロイ", "ポックル" });
            uniqueCombination.Add("恵みの雨の妖精", new string[] { "ポックル", "ファゾリン" });
            uniqueCombination.Add("梅雨だくシスターズ", new string[] { "第二型メンスロイ", "第二型シャビ" });
            uniqueCombination.Add("操り人形の旋律", new string[] { "第二型メンスロイ", "第二型マルベッタ" });
            uniqueCombination.Add("グラスハート", new string[] { "支援型ヤマト", "姫憂型茶々" });
            uniqueCombination.Add("雷雲アタッカー", new string[] { "支援型ランジュルグ", "第二型ステファン" });
            uniqueCombination.Add("道化師の婚礼", new string[] { "純白型ディナダン", "純白型リトルグレイ" });
            uniqueCombination.Add("守られるよりも 守りたい…マジで", new string[] { "華嫁型アイシス", "支援型タルコノミ" });
            uniqueCombination.Add("嫁は萌えているか", new string[] { "純白型セイント", "純白型リトルグレイ" });
            uniqueCombination.Add("控えめ花嫁", new string[] { "華嫁型ヘイムスクリングラ", "華嫁型アイシス" });
            uniqueCombination.Add("小姑（獣）「嫁にはやらん！」", new string[] { "華嫁型メイシャル", "純白型ユーウェインのライオン" });
            uniqueCombination.Add("疾走花嫁", new string[] { "華嫁型エイル", "純白型セイント" });
            uniqueCombination.Add("スウィーツ・嫁", new string[] { "純白型リトルグレイ", "純白型スリング" });
            uniqueCombination.Add("乙嫁の愛の夢", new string[] { "純白型クラッキー", "純白型ユーウェインのライオン" });
            uniqueCombination.Add("お兄ちゃんは私のものなんだから！", new string[] { "第二型マンタンク", "義妹型エマ" });
            uniqueCombination.Add("が、頑張るよ！兄様の為だもん！", new string[] { "第二型マンタンク", "支援型カーペンダー" });
            uniqueCombination.Add("しょうがないなぁ、お兄ちゃんは…", new string[] { "義妹型クィリアー", "義妹型クインズマフィー" });
            uniqueCombination.Add("お兄ちゃん、元気出して！", new string[] { "義妹型エマ", "支援型パリュム" });
            uniqueCombination.Add("妹は俺の嫁", new string[] { "義妹型エピリア", "華嫁型メイシャル" });
            uniqueCombination.Add("ふくろうのキッス", new string[] { "義妹型メイシャル", "華嫁型メイシャル" });
            uniqueCombination.Add("わわっ、お兄ちゃんすっごーい！", new string[] { "義妹型メイシャル", "義妹型エピリア" });



            // 固有の組み合わせによるコンボ
            comboList.Add(new ComboDto { Name = "12月の花嫁", HpUp = 8, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "アークブラスト", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "アーサーの嫁入り？", HpUp = 4, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "アームドセレクション", HpUp = 0, AtkUp = 9 });
            comboList.Add(new ComboDto { Name = "アーランドの錬金術士", HpUp = 10, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "アウターワールド", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "アブソリュートルーラー", HpUp = 0, AtkUp = 9 });
            comboList.Add(new ComboDto { Name = "新たな目覚め？？", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "アンノウンフォース", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "アンラッキーナンバー", HpUp = 20, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "インターセクトリサーチ", HpUp = 14, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "インビンシブル", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "インペリアルゴールド", HpUp = 11, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ウェイクアップオアスリープ", HpUp = 8, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "エターナルギア", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(1)", HpUp = 0, AtkUp = 14 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(2)", HpUp = 0, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(3)", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(4)", HpUp = 0, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(5)", HpUp = 0, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "エレメントリンク(6)", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "オーディエンス", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "オールブルーム", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "お色直し", HpUp = 4, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "おさなづま", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "おしかけ女房", HpUp = 6, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "オバケは苦手！？", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "女の子と勘違い？", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "華恋な武闘派", HpUp = 0, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "華恋な肉食系", HpUp = 0, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "クイーンズプレステージ", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "グランドシールド", HpUp = 5, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "クレイジーホワイト", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "サーヴァント(1)", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "サーヴァント(2)", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "シェアードセンス", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ジェネレーションロード", HpUp = 4, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "じゃあライオンはもらっていきますね", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "スイートキャット", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "スタートアップ", HpUp = 6, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "ストームレイン", HpUp = 0, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "ストレイトライナー", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "聖杯の祝福・アーサー", HpUp = 0, AtkUp = 15 });
            comboList.Add(new ComboDto { Name = "聖杯の祝福・ガウェイン", HpUp = 5, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "セカンドエフェクト", HpUp = 20, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ソウルトレード", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "その鎧、ふざけてるだろ", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "ソリッドファイター", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "ダートガールズ", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "タクティクスアシスト", HpUp = 5, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ダメージオブスネイク", HpUp = 7, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ツーペア", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "ディスコンテントエクスプロード", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "ディスティニーリンク", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "トップトレーナー1", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "トップトレーナー2", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "トップトレーナー3", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "トラストミー", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "トリプルウェポン", HpUp = 0, AtkUp = 11 });
            comboList.Add(new ComboDto { Name = "ハート&エンジェル", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "パートナー・アサルト", HpUp = 9, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "パートナー・テクニカル", HpUp = 9, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "パートナー・マジック", HpUp = 9, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "白鳥達の宴", HpUp = 7, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "白鳥達の湖1", HpUp = 3, AtkUp = 3 });
            comboList.Add(new ComboDto { Name = "白鳥達の湖2", HpUp = 3, AtkUp = 3 });
            comboList.Add(new ComboDto { Name = "白鳥達の湖3", HpUp = 3, AtkUp = 3 });
            comboList.Add(new ComboDto { Name = "バトルスピナー", HpUp = 8, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "ビッグガーディアン", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "ビューティフルカラー", HpUp = 0, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "ブロークンハート", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "ホムンクルス", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "マネーゲーム", HpUp = 0, AtkUp = 7 });
            comboList.Add(new ComboDto { Name = "ミリオンソード", HpUp = 0, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "メイクアップ", HpUp = 11, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "もふもふ嫁", HpUp = 4, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ラテントエナジー", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "リアリティディスクローズ", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "リヴェンジャー(1)", HpUp = 0, AtkUp = 10 });
            comboList.Add(new ComboDto { Name = "リヴェンジャー(2)", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "リバースグラップラー", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "リファインメントタスク", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "レイオブスピリット", HpUp = 15, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "レイルブレイブ", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "ロイヤルロード", HpUp = 0, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ワイフイズドラゴン", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ワイルドペア", HpUp = 0, AtkUp = 4 });
            comboList.Add(new ComboDto { Name = "法王と三銃士", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "囚われの法王", HpUp = 4, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "かつての仲間たち", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "一方的なぞっこんラブ", HpUp = 6, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "ねこはいいにゃ", HpUp = 3, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "かっかっか･･･！", HpUp = 0, AtkUp = 3 });
            comboList.Add(new ComboDto { Name = "ショウタ～イム", HpUp = 0, AtkUp = 5 });
            comboList.Add(new ComboDto { Name = "拡散性 閏月戈", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "雨と風の輪舞曲", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "森と風の幻想曲", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "恵みの雨の妖精", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "梅雨だくシスターズ", HpUp = 12, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "操り人形の旋律", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "グラスハート", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "雷雲アタッカー", HpUp = 0, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "道化師の婚礼", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "守られるよりも 守りたい…マジで", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "嫁は萌えているか", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "控えめ花嫁", HpUp = 0, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "小姑（獣）「嫁にはやらん！」", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "疾走花嫁", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "スウィーツ・嫁", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "乙嫁の愛の夢", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "お兄ちゃんは私のものなんだから！", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "が、頑張るよ！兄様の為だもん！", HpUp = 0, AtkUp = 6 });
            comboList.Add(new ComboDto { Name = "しょうがないなぁ、お兄ちゃんは…", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "お兄ちゃん、元気出して！", HpUp = 6, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "妹は俺の嫁", HpUp = 0, AtkUp = 15 });
            comboList.Add(new ComboDto { Name = "ふくろうのキッス", HpUp = 10, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "わわっ、お兄ちゃんすっごーい！", HpUp = 0, AtkUp = 10 });

            // コアメンバーと特定の型からの組み合わせ
            comboList.Add(new ComboDto { Name = "華嫁愛唄",HpUp=16,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "華嫁愛唄・ライズ",HpUp=24,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "華嫁愛唄・クラウン",HpUp=30,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "華嫁愛唄・ファイナル",HpUp=40,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "純白愛唄",HpUp=10,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "純白愛唄・ライズ",HpUp=20,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "純白愛唄・クラウン",HpUp=28,AtkUp=0 });
            comboList.Add(new ComboDto { Name = "純白愛唄・ファイナル", HpUp = 40, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ビューティーウェディング", HpUp = 8, AtkUp = 8 });
            comboList.Add(new ComboDto { Name = "ビューティーウェディング・ライズ", HpUp = 12, AtkUp = 12 });
            comboList.Add(new ComboDto { Name = "ビューティーウェディング・クラウン", HpUp = 16, AtkUp = 16 });
            comboList.Add(new ComboDto { Name = "ピュアハート", HpUp = 8, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ピュアハート・ライズ", HpUp = 12, AtkUp = 0 });
            comboList.Add(new ComboDto { Name = "ピュアハート・クラウン", HpUp = 16, AtkUp = 0 });

            identifications.Add("ビューティーウェディング", new string[] { "華嫁型ニムエ", "華嫁型ヘイムスクリングラ", "華嫁型マシロ", "華嫁型エイル", "華嫁型メイシャル" });
            identifications.Add("ピュアハート", new string[] { "華嫁型レイレイ", "華嫁型フワニータ", "華嫁型アイシス", "華嫁型エイル", "華嫁型メイシャル" });


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sections"></param>
        public void Integration(List<KnightSection> sections)
        {
            Data.Atack = 0;
            Data.HitPoint = 0;
            Data.Cost = 0;
            Data.Combo.Clear();
            // 初期化
            foreach (KnightSection section in sections)
            {
                Data.Atack += section.Attack;
                Data.HitPoint += section.HitPoint;
                Data.Cost += section.Cost;
                //switch (section.Force)
                //{
                //    case Force.MAGIC:
                //        Data.MagicCount++;
                //        break;
                //    case Force.SWORD:
                //        Data.SwordCount++;
                //        break;
                //    case Force.TECHNO:
                //        Data.TechnoCount++;
                //        break;
                //}
            }
        }


        /// <summary>
        /// ラッシュコンボ判定
        /// </summary>
        /// <param name="sections"></param>
        public void Rush(List<KnightSection> sections)
        { 
            if(sections.Count()==12)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name=="ラッシュコンボ・クラウン"));
            else if (sections.Count() > 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ラッシュコンボ・ライズ"));
            else if (sections.Count() > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ラッシュコンボ"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sections"></param>
        public void Male(List<KnightSection> sections)
        {
            int count = sections.Where(a => a.Sex == Sex.MALE).Count();
            if(count > 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンスコンボ・クラウン"));
            else if(count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンスコンボ・ライズ"));
            else if (count > 2)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンスコンボ"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sections"></param>
        public void Female(List<KnightSection> sections)
        {
            int count = sections.Where(a => a.Sex == Sex.FEMALE).Count();
            if (count == 12)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンセスコンボ・クラウン"));
            else if (count > 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンセスコンボ・ライズ"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "プリンセスコンボ"));
        }

        /// <summary>
        /// 剣
        /// </summary>
        /// <param name="sections"></param>
        public void ForceSword(List<KnightSection> sections)
        {
            int count = ForceCounter(sections, Force.SWORD);
            if (count > 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトコンボ・クラウン"));
            else if (count > 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトコンボ・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトコンボ"));
        }

        /// <summary>
        /// テクノ
        /// </summary>
        /// <param name="sections"></param>
        public void ForceTechno(List<KnightSection> sections)
        {
            int count = ForceCounter(sections, Force.TECHNO);
            if (count > 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルコンボ・クラウン"));
            else if (count > 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルコンボ・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルコンボ"));
        }

        /// <summary>
        /// マジック
        /// </summary>
        /// <param name="sections"></param>
        public void ForceMagic(List<KnightSection> sections)
        {
            int count = ForceCounter(sections, Force.MAGIC);
            if (count > 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックコンボ・クラウン"));
            else if (count > 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックコンボ・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックコンボ"));
        }
        
        /// <summary>
        /// マジック
        /// </summary>
        /// <param name="sections"></param>
        public void ForceFairy(List<KnightSection> sections)
        {
            int count = ForceCounter(sections, Force.FAIRY);
            if (count > 10)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "フェアリーコンボ・クラウン"));
            else if (count > 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "フェアリーコンボ・ライズ"));
            else if (count > 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "フェアリーコンボ"));
            else if (count > 2)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "フェアリーコンボ・ライト"));
        }

        /// <summary>
        /// 指定されたFORCEがいくつ含まれるか判定する
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        private int ForceCounter(List<KnightSection> sections, Force force)
        {
            return sections.Where(a => a.Force == force).Count();
        }


        /// <summary>
        /// アサルト
        /// </summary>
        /// <param name="sections"></param>
        public void PrivateForceAssault(List<KnightSection> sections)
        {
            int count = PrivateForceCounter(sections, PrivateForce.ASSAULT);
            if (count > 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトフォース・クラウン"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトフォース・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アサルトフォース"));
        }

        /// <summary>
        /// テクニカル
        /// </summary>
        /// <param name="sections"></param>
        public void PrivateForceTechnical(List<KnightSection> sections)
        {
            int count = PrivateForceCounter(sections, PrivateForce.TECHNICAL);
            if (count > 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルフォース・クラウン"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルフォース・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "テクニカルフォース"));
        }

        /// <summary>
        /// 魔法
        /// </summary>
        /// <param name="sections"></param>
        public void PrivateForceMagic(List<KnightSection> sections)
        {
            int count = PrivateForceCounter(sections, PrivateForce.MAGIC);
            if (count > 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックフォース・クラウン"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックフォース・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マジックフォース"));
        }

        /// <summary>
        /// 固有の勢力の数を返す
        /// </summary>
        /// <param name="sections"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        private int PrivateForceCounter(List<KnightSection> sections, PrivateForce force)
        {
            return sections.Where(a => a.PrivateForce == force).Count();
        }

        /// <summary>
        /// 第二型コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void SecondCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "第二型");
            if(count==12)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ナイトコンボ・クラウン"));
            else if (count > 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ナイトコンボ・ライズ"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ナイトコンボ"));
        }

        /// <summary>
        /// 支援型コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void SupportCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "支援型");
            if (count == 12)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "サポートコンボ・クラウン"));
            else if (count > 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "サポートコンボ・ライズ"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "サポートコンボ"));
        }

        /// <summary>
        /// 特異型コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void SingularCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "特異型");
            if (count == 12)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "レジェンドコンボ・クラウン"));
            else if (count > 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "レジェンドコンボ・ライズ"));
            else if (count > 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "レジェンドコンボ"));
        }

        /// <summary>
        /// 絢爛型コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void GorgeousCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "絢爛型");
            if (count > 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ジュエリーコンボ・ライズ"));
            else if (count > 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ジュエリーコンボ"));
        }

        /// <summary>
        /// エクスプローラーコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void ExplorerCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "エクスプローラー型");
            if (count == 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "エクスプローラー・クラウン"));
            else if (count == 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "エクスプローラー・ライズ"));
            else if (count == 2)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "エクスプローラー"));
        }

        /// <summary>
        /// 巫《かんなぎ》コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void KannagiCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "巫型");
            if (count >= 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "巫《かんなぎ》コンボ・クラウン"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "巫《かんなぎ》コンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "巫《かんなぎ》コンボ"));
        }

        /// <summary>
        /// 口寄《くちよせ》コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void KuchiyoseCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "口寄型");
            if (count >= 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "口寄《くちよせ》コンボ・クラウン"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "口寄《くちよせ》コンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "口寄《くちよせ》コンボ"));
        }

        /// <summary>
        /// クィーンコンボ
        /// </summary>
        /// <param name="sections"></param>
        //public void QueenCombo(List<KnightSection> sections)
        //{
        //    int count = KnightCounter(sections, "口寄型");
        //    if (count >= 6)
        //        this.Data.Combo.AddRange(comboList.Where(a => a.Name == "クィーンコンボ・クラウン"));
        //    else if (count >= 3)
        //        this.Data.Combo.AddRange(comboList.Where(a => a.Name == "クィーンコンボ・ライズ"));
        //    else if (count >= 2)
        //        this.Data.Combo.AddRange(comboList.Where(a => a.Name == "クィーンコンボ"));
        //}

        /// <summary>
        /// デビルコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void DevilCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "堕天型");

            if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "デビルコンボ"));
        }

        /// <summary>
        /// ビーストコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void BeastCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "幻獣型") + KnightCounter(sections, "超獣型");
            if (count >= 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ビーストコンボ・ライズ"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ビーストコンボ"));
        }

        /// <summary>
        /// バレンタインコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void ValentineCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "華恋型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "バレンタインコンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "バレンタインコンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "バレンタインコンボ"));
        }

        /// <summary>
        /// 麻雀コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void MahjonggCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "麻雀型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "麻雀コンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "麻雀コンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "麻雀コンボ"));
        }

        /// <summary>
        /// ハイスクールコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void HighschoolCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "学徒型") + KnightCounter(sections, "教練型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ハイスクールコンボ・クラウン"));
            else if (count >= 7)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ハイスクールコンボ・ライズ"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ハイスクールコンボ"));
        }

        /// <summary>
        /// アーランドコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void ArlandCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "アーランド型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アーランドコンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アーランドコンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "アーランドコンボ"));
        }

        /// <summary>
        /// 錬金術コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void AlchemistCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "錬金術型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "錬金術コンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "錬金術コンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "錬金術コンボ"));
        }

        /// <summary>
        /// ブレイブリーコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void BravelyCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "ブレイブリー型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブレイブリーコンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブレイブリーコンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブレイブリーコンボ"));
        }

        /// <summary>
        /// ブライダルコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void BridalCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "純白型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブライダルコンボ・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブライダルコンボ・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ブライダルコンボ"));
        }

        /// <summary>
        /// マリッジコンボ
        /// </summary>
        /// <param name="sections"></param>
        public void MarriageCombo(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "華嫁型");
            if (count >= 10)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マリッジコンボ・ファイナル"));
            else if (count >= 8)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マリッジコンボ・クラウン"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マリッジコンボ・ライズ"));
            else if (count >= 2)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "マリッジコンボ"));
        }

        /// <summary>
        /// ヤンガーシスター
        /// </summary>
        /// <param name="sections"></param>
        public void YoungerSister(List<KnightSection> sections)
        {
            int count = KnightCounter(sections, "義妹型");
            if (count >= 9)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ヤンガーシスター・クラウン"));
            else if (count >= 6)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ヤンガーシスター・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ヤンガーシスター"));
        }

        /// <summary>
        /// 純白愛唄
        /// </summary>
        /// <param name="sections"></param>
        public void PureWhiteSong(List<KnightSection> sections)
        {
            KnightSection[] knight = sections.Where(a => a.KnightName == "華嫁型ヘイムスクリングラ").ToArray();
            if (knight.Count()>0)
            {
                int count = KnightCounter(sections, "純白型");
                if(count >=6 )
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "純白愛唄・ファイナル"));
                else if (count >= 4)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "純白愛唄・クラウン"));
                else if (count >= 3)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "純白愛唄・ライズ"));
                else if (count >= 2)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "純白愛唄"));
            }
        }

        /// <summary>
        /// 華嫁愛唄
        /// </summary>
        /// <param name="sections"></param>
        public void BrideSong(List<KnightSection> sections)
        {
            KnightSection[] knight = sections.Where(a => a.KnightName == "華嫁型ヘイムスクリングラ").ToArray();
            if (knight.Count() > 0)
            {
                int count = KnightCounter(sections, "華嫁型");
                if (count >= 7)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "華嫁愛唄・ファイナル"));
                else if (count >= 5)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "華嫁愛唄・クラウン"));
                else if (count >= 4)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "華嫁愛唄・ライズ"));
                else if (count >= 3)
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == "華嫁愛唄"));
            }
        }

        /// <summary>
        /// ビューティーウェディング
        /// </summary>
        /// <param name="sections"></param>
        public void Beauty(List<KnightSection> sections)
        {
            int count = Counter(sections, identifications["ビューティーウェディング"]);
            if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ビューティーウェディング・クラウン"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ビューティーウェディング・ライズ"));
            else if (count >= 2)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ビューティーウェディング"));
        }
        /// <summary>
        /// ピュアハート
        /// </summary>
        /// <param name="sections"></param>
        public void PureHeart(List<KnightSection> sections)
        {
            int count = Counter(sections, identifications["ピュアハート"]);
            if (count >= 5)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ピュアハート・クラウン"));
            else if (count >= 4)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ピュアハート・ライズ"));
            else if (count >= 3)
                this.Data.Combo.AddRange(comboList.Where(a => a.Name == "ピュアハート"));
        }

        // 指定されたsectionの中に特定の騎士が何個が含まれるか返す
        private int Counter(List<KnightSection> sections, string[] member)
        {
            int result = 0;
            foreach(string knight in member)
            {
                KnightSection[] ret = sections.Where(s => s.KnightName == knight).ToArray();
                if (ret.Length > 0)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// 指定された名前を含む騎士数を返す
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private int KnightCounter(List<KnightSection> pair, string name)
        {
            int result = 0;
            KnightSection[] ret = pair.Where(knight => knight.KnightName.IndexOf(name) == 0).ToArray();
            if (ret != null)
                result = ret.Length;

            return result;
        }

        /// <summary>
        /// 固有コンボ
        /// </summary>
        /// <param name="sections"></param>
        public void UniqueCombo(List<KnightSection> sections)
        { 
            foreach (var val in this.uniqueCombination)
            {
                if(UniqueCombo(sections, val.Value))
                    this.Data.Combo.AddRange(comboList.Where(a => a.Name == val.Key));
            }
        }



        /// <summary>
        /// 個別に組み合わせで発生するコンボ
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="nameList"></param>
        /// <returns></returns>
        private bool UniqueCombo(List<KnightSection> pair, string[] nameList)
        {
            bool find = false;
            if (nameList != null)
            {
                foreach (string name in nameList)
                {
                    KnightSection[] ret = pair.Where(knight => knight.KnightName == name).ToArray();
                    find = (ret.Length > 0);
                    if (!find)
                        break;
                }
            }
            return find;
        }

        /// <summary>
        /// 
        /// </summary>
        public void FinalPowerCalc()
        { 
            double hp = 100;
            double atk = 100;
            foreach (ComboDto val in Data.Combo)
            {
                hp += val.HpUp;
                atk += val.AtkUp;
            }
            this.Data.HitPoint = (uint)((double)this.Data.HitPoint * hp / 100.0);
            this.Data.Atack = (uint)((double)this.Data.Atack * atk / 100.0);
        }
    }
}
