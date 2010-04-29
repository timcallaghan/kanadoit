using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KanaDoIT
{
    public class KanaCharInfo
    {
        public KanaKey Kana { get; set; }
        public FontFamily KanaFont { get; set; }

        public KanaCharInfo(KanaKey key, FontFamily ff)
        {
            Kana = key;
            KanaFont = ff;
        }
    }

    public class NounInfo
    {
        public Uri ImageFilePath { get; private set; }

        private List<KanaCharInfo> KanaWord;
        private string BaseImagePath = @"/KanaDoIT;component/Images/";
        private string EnglishWord;

        private static DictionaryKanaInfo dictKanaInfo = new DictionaryKanaInfo();

        public NounInfo(string strImageName, string strEnglishWord, List<KanaCharInfo> listCharInfo)
        {
            ImageFilePath = new Uri(BaseImagePath + strImageName, UriKind.Relative);
            EnglishWord = strEnglishWord;
            KanaWord = listCharInfo;
        }

        public TextBlock GetNounKana()
        {
            TextBlock tb = new TextBlock();

            foreach (KanaCharInfo charInfo in KanaWord)
            {
                Run textRun = new Run();
                textRun.FontFamily = charInfo.KanaFont;
                textRun.FontSize = 26;
                textRun.Text = dictKanaInfo[charInfo.Kana].FontCode;
                tb.Inlines.Add(textRun);
            }

            return tb;
        }
    }

    public class DictionaryNouns : Dictionary<int, NounInfo>
    {
        private Random random;

        public DictionaryNouns()
        {
            int nIndex = 0;

            List<KanaCharInfo> listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.PA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SO, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KO, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("AJ_Computer.xaml", "Computer", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.PE, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("zeimusu_Pen.xaml", "Pen", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KE, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.TA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.BA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.U, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("BigRedSmile_A_Mobile_Phone.xaml", "Mobile Phone", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.HO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("jean_victor_balin_book.xaml", "Book", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.ME, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.NE, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("johnny_automatic_eyeglasses_1.xaml", "Glasses", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GI, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("johnny_automatic_key.xaml", "Key", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.HU, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("wsnaccad_LEATHER_WALLET.xaml", "Wallet", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SA, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("LX_Black_Umbrella.xaml", "Umbrella", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KU, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RE, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.ZI, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DOUBLE, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.TO, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.LONG, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DO, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("Muga_Golden_Credit_Card.xaml", "Credit Card", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.O, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.NE, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("n_kamil_Money_-_banknotes_and_coin.xaml", "Money", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.MI, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.ZU, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("rg1024_Set_of_water_drops.xaml", "Water", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.BA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DOUBLE, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GU, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("TheresaKnott_handbag.xaml", "Handbag", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.DE, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.WA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.BA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.U, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("tim99_Simple_Telephone.xaml", "Telephone", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.TO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KE, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("valessiobrito_Clock_Alarm.xaml", "Clock", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.U, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DE, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KE, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("webmichl_wristwatch_1_-_chronometer.xaml", "Wrist Watch", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KYO, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.U, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SYO, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("wipp_Address_Book.xaml", "Textbook", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GU, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SU, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("yves_guillou_glasses.xaml", "Sunglasses", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SYA, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.LONG, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.PU, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.PE, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SI, DictionaryKanaInfo.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RU, DictionaryKanaInfo.KatakanaFont));
            this.Add(nIndex++, new NounInfo("itomato_Technical_Drawing_Pencil.xaml", "Pacer Pencil", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.BA, DictionaryKanaInfo.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, DictionaryKanaInfo.HiraganaFont));
            this.Add(nIndex++, new NounInfo("szymonraj_Shopping_bag.xaml", "Bag", listChars));


            random = new Random();
        }

        public int GetRandomKey()
        {
            return random.Next(this.Count);
        }

        public List<NounInfo> GetRandonNounList()
        {
            List<NounInfo> listNouns = new List<NounInfo>();

            int nFound = 0;
            while (nFound < 4)
            {
                int nTempKey = GetRandomKey();
                if (!listNouns.Contains(this[nTempKey]))
                {
                    ++nFound;
                    listNouns.Add(this[nTempKey]);
                }
            }

            return listNouns;
        }
    }
}