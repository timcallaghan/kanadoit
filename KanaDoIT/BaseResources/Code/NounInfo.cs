using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Arbaureal.KanaDoIT.BaseResources
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
        private string BaseImagePath = @"/BaseResources;component/Images/";
        private string EnglishWord;

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
                textRun.Text = DictionaryKanaInfo.Instance[charInfo.Kana].FontCode;
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
            listChars.Add(new KanaCharInfo(KanaKey.PA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SO, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KO, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("AJ_Computer.xaml", "Computer", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.PE, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("zeimusu_Pen.xaml", "Pen", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.TA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.WA, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("BigRedSmile_A_Mobile_Phone.xaml", "Mobile Phone", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.HO, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("jean_victor_balin_book.xaml", "Book", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.ME, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.NE, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("johnny_automatic_eyeglasses_1.xaml", "Glasses", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GI, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("johnny_automatic_key.xaml", "Key", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.HU, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("wsnaccad_LEATHER_WALLET.xaml", "Wallet", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SA, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("LX_Black_Umbrella.xaml", "Umbrella", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KU, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RE, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.ZI, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DOUBLE, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.TO, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.LONG, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DO, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("Muga_Golden_Credit_Card.xaml", "Credit Card", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.O, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.NE, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("n_kamil_Money_-_banknotes_and_coin.xaml", "Money", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.MI, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.ZU, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("rg1024_Set_of_water_drops.xaml", "Water", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.BA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DOUBLE, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GU, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("TheresaKnott_handbag.xaml", "Handbag", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.DE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.WA, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("tim99_Simple_Telephone.xaml", "Telephone", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.TO, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("valessiobrito_Clock_Alarm.xaml", "Clock", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.U, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.DO, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KE, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.I, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("webmichl_wristwatch_1_-_chronometer.xaml", "Wrist Watch", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KYO, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.U, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SYO, KanaFont.HiraganaFont));
            this.Add(nIndex++, new NounInfo("wipp_Address_Book.xaml", "Textbook", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.GU, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SU, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("yves_guillou_glasses.xaml", "Sunglasses", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.SYA, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.LONG, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.PU, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.PE, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.SI, KanaFont.KatakanaFont));
            listChars.Add(new KanaCharInfo(KanaKey.RU, KanaFont.KatakanaFont));
            this.Add(nIndex++, new NounInfo("itomato_Technical_Drawing_Pencil.xaml", "Pacer Pencil", listChars));

            listChars = new List<KanaCharInfo>();
            listChars.Add(new KanaCharInfo(KanaKey.KA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.BA, KanaFont.HiraganaFont));
            listChars.Add(new KanaCharInfo(KanaKey.N, KanaFont.HiraganaFont));
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