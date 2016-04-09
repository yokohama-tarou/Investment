using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Finance;
using MillionArthurApplication.Xml;

namespace MillionArthurApplication
{
    /// <summary>
    /// ファイル操作用
    /// </summary>
    public static class FileUtility
    {
        /// <summary>
        /// 今回処理したファイルを保存する
        /// </summary>
        /// <param name="m"></param>
        public static void SaveBeforeFile(int m)
        {
            FileCopy(Properties.Resources.SECTION_FILE_NAME, m);
            FileCopy(Properties.Resources.INI_FILE_NAME, m);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void SaveXmlConfig(IntegrationDto data, List<KnightSection> sections, int m)
        {
            try
            {
                MillionConfig config = GetMillionConfig(data, sections, m);
                XmlSerializer objXmlSerializer;
                using (FileStream objfs = new FileStream("MillionConfig.xml", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {

                    //シリアル化し、XMLファイルに保存する
                    objXmlSerializer = new XmlSerializer(typeof(MillionConfig));
                    objXmlSerializer.Serialize(objfs, config);

                    //設定ファイルクローズ
                    objfs.Close();
                }
            }
            catch
            { 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sections"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static MillionConfig GetMillionConfig(IntegrationDto data, List<KnightSection> sections, int m)
        {
            MillionConfig config = LoadMillionConfig();
            Strongest strongest = GetBeforeNo1(config, m);
            strongest.Attack = data.Atack;
            strongest.Hitpoint = data.HitPoint;
            strongest.Cost = data.Cost;
            strongest.Knights = new string[sections.Count()];
            for (int i = 0; i < sections.Count(); i++ )
            {
                strongest.Knights[i] = sections[i].KnightName;
            }
            strongest.ComboList = new string[data.Combo.Count()];
            for (int i = 0; i < data.Combo.Count(); i++)
            {
                strongest.ComboList[i] = data.Combo[i].Name;
            }
            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static IntegrationDto GetBeforeNo1(int m)
        {
            MillionConfig config = LoadMillionConfig();
            Strongest strongest = GetBeforeNo1(config, m);
            IntegrationDto dto = new IntegrationDto();
            dto.Atack = strongest.Attack;
            dto.Cost = strongest.Cost;
            if (dto.Cost == 0)
                dto.Cost = 999;
            dto.HitPoint = strongest.Hitpoint;
            dto.Combo = new List<ComboDto>();
            foreach (string val in strongest.ComboList)
            {
                ComboDto data = new ComboDto();
                data.Name = val;
                dto.Combo.Add(data);
            }
            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static List<KnightSection> GetBeforeNo1Section(int m)
        {
            MillionConfig config = LoadMillionConfig();
            Strongest strongest = GetBeforeNo1(config, m);
            List<KnightSection> result = new List<KnightSection>();
            
            foreach (string val in strongest.Knights)
            {
                result.Add(new KnightSection(val));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static Strongest GetBeforeNo1(MillionConfig config, int m)
        {
            Strongest strongest = new Strongest(); ;
            if (m == 3)
                strongest = config.Strongest3;
            if (m == 6)
                strongest = config.Strongest6;
            if (m == 9)
                strongest = config.Strongest9;
            if (m == 12)
                strongest = config.Strongest12;
            return strongest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MillionConfig LoadMillionConfig()
        {
            MillionConfig config = new MillionConfig();
            if(System.IO.File.Exists("MillionConfig.xml"))
            {
                System.Xml.Serialization.XmlSerializer objXmlSerializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(MillionConfig));
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    "MillionConfig.xml", new System.Text.UTF8Encoding(false));
                config = (MillionConfig)objXmlSerializer.Deserialize(sr);
                //設定ファイルクローズ
                sr.Close();
            }

            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="m"></param>
        private static void FileCopy(string fileName, int m)
        {
            string dir = Directory.GetCurrentDirectory();
            string old_path = Path.Combine(dir, fileName);
            string new_dir = GetBeforeFolder(m);
            string new_path = Path.Combine(new_dir, fileName);
            if (!Directory.Exists(new_dir))
                Directory.CreateDirectory(new_dir);
            File.Copy(old_path, new_path,true);
        }

        /// <summary>
        /// 差分の騎士を返す
        /// </summary>
        /// <returns></returns>
        public static List<string> LoadDifferenceKnight(List<KnightSection> now_sections, int m)
        {
            List<string> result = new List<string>();
            // 前回iniの取得
            List<KnightSection> before = GetSectionData(GetBeforeFolder(m),m);
            // 差分の取得
            foreach (KnightSection val in now_sections)
            {
                KnightSection[] array = before.Where(s => s.KnightName == val.KnightName).ToArray();
                // 新しく追加されたセクションらしい
                if (array.Length == 0)
                    result.Add(val.KnightName);
                else
                {
                    if (val.HitPoint != array[0].HitPoint || val.Attack != array[0].Attack)
                        result.Add(val.KnightName);
                }
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<string> GetSectionNames(string dir = null)
        {
            if(dir!=null)
                return CsvReader.GetFirstRows(dir,Properties.Resources.SECTION_FILE_NAME);
            else
                return CsvReader.GetFirstRows(Properties.Resources.SECTION_FILE_NAME);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetBeforeFolder(int m)
        {
            string before = Path.Combine(Directory.GetCurrentDirectory(),
                Properties.Resources.BEFORE_FOLDER,m.ToString());
            return before;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static List<KnightSection> GetSectionData(string dir, int m)
        {
            List<KnightSection> result = new List<KnightSection>();
            List<string> sections = GetSectionNames(dir);
            foreach (string section in sections)
            {
                result.Add(new KnightSection(dir, section));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void InitializeBeforeFile()
        {
            ExitFiles(3);
            ExitFiles(6);
            ExitFiles(9);
            ExitFiles(12);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void ExitFiles(int m)
        {
            string new_dir = GetBeforeFolder(m);
            string section_path = Path.Combine(new_dir, Properties.Resources.SECTION_FILE_NAME);
            string ini_path = Path.Combine(new_dir, Properties.Resources.INI_FILE_NAME);
            if(!Directory.Exists(new_dir))
                Directory.CreateDirectory(new_dir);
            if(!(File.Exists(section_path)))
            {
                FileStream fs = File.Create(section_path);
                fs.Close();
            }
            if (!(File.Exists(ini_path)))
            {
                FileStream fs = File.Create(ini_path);
                fs.Close();
            }
        }
    }
}
