using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Arbaureal.KanaDoIT.BaseResources
{
    public class KanaInfo
    {
        public string FontCode { get; private set; }
        public string Romaji { get; private set; }
        public Uri SoundFilePath { get; private set; }

        private string BaseSoundPath = @"/BaseResources;component/Sounds/";

        public KanaInfo(string strFontCode, string strRomaji, string strSoundFile)
        {
            FontCode = strFontCode;
            Romaji = strRomaji;

            string strFullPath = BaseSoundPath + strSoundFile;
            SoundFilePath = new Uri(strFullPath, UriKind.Relative);
        }
    }

    // Keys used to store kana values in the lookup dictionary
    public enum KanaKey
    {
        A,  I,  U,  E,  O,
        KA, KI, KU, KE, KO,  GA, GI, GU, GE, GO,  KYA, KYU, KYO,  GYA, GYU, GYO,
        SA, SI, SU, SE, SO,  ZA, ZI, ZU, ZE, ZO,  SYA, SYU, SYO,  ZYA, ZYU, ZYO,
        TA, TI, TU, TE, TO,  DA, DI, DU, DE, DO,  TYA, TYU, TYO,
        NA, NI, NU, NE, NO,                       NYA, NYU, NYO,
        HA, HI, HU, HE, HO,  BA, BI, BU, BE, BO,  PA, PI, PU, PE, PO,  HYA, HYU, HYO,  BYA, BYU, BYO,  PYA, PYU, PYO,
        MA, MI, MU, ME, MO,                       MYA, MYU, MYO,
        YA,     YU,     YO,
        RA, RI, RU, RE, RO,                       RYA, RYU, RYO,
        WA,             WO,
        N,
        DOUBLE,
        LONG,
        A_SMALL, I_SMALL, U_SMALL, E_SMALL, O_SMALL,
        COMMA, FULLSTOP
    }

    public enum KanaType
    {
        Hiragana,
        Katakana
    }

    public class DictionaryKanaInfo : Dictionary<KanaKey, KanaInfo>
    {
        public static FontFamily HiraganaFont { get; private set; }
        public static FontFamily KatakanaFont { get; private set; }

        static DictionaryKanaInfo()
        {
            HiraganaFont = new FontFamily("/BaseResources;component/Fonts/PJ_Hiragana.TTF#PJ Hiragana");
            KatakanaFont = new FontFamily("/BaseResources;component/Fonts/PJ_Katakana.TTF#PJ Katakana");
        }

        public DictionaryKanaInfo()
        {
            this.Add(KanaKey.A,  new KanaInfo("1", "a", "a.mp3"));
            this.Add(KanaKey.I, new KanaInfo("2", "i", "i.mp3"));
            this.Add(KanaKey.U, new KanaInfo("3", "u", "u.mp3"));
            this.Add(KanaKey.E, new KanaInfo("4", "e", "e.mp3"));
            this.Add(KanaKey.O, new KanaInfo("5", "o", "o.mp3"));

            this.Add(KanaKey.KA, new KanaInfo("q", "ka", "ka.mp3"));
            this.Add(KanaKey.KI, new KanaInfo("w", "ki", "ki.mp3"));
            this.Add(KanaKey.KU, new KanaInfo("e", "ku", "ku.mp3"));
            this.Add(KanaKey.KE, new KanaInfo("r", "ke", "ke.mp3"));
            this.Add(KanaKey.KO, new KanaInfo("t", "ko", "ko.mp3"));

            this.Add(KanaKey.GA, new KanaInfo("!", "ga", "ga.mp3"));
            this.Add(KanaKey.GI, new KanaInfo("@", "gi", "gi.mp3"));
            this.Add(KanaKey.GU, new KanaInfo("#", "gu", "gu.mp3"));
            this.Add(KanaKey.GE, new KanaInfo("$", "ge", "ge.mp3"));
            this.Add(KanaKey.GO, new KanaInfo("%", "go", "go.mp3"));

            this.Add(KanaKey.KYA, new KanaInfo("w<", "kya", "kya.mp3"));
            this.Add(KanaKey.KYU, new KanaInfo("w>", "kyu", "kyu.mp3"));
            this.Add(KanaKey.KYO, new KanaInfo("w?", "kyo", "kyo.mp3"));

            this.Add(KanaKey.GYA, new KanaInfo("@<", "gya", "gya.mp3"));
            this.Add(KanaKey.GYU, new KanaInfo("@>", "gyu", "gyu.mp3"));
            this.Add(KanaKey.GYO, new KanaInfo("@?", "gyo", "gyo.mp3"));

            this.Add(KanaKey.SA, new KanaInfo("a", "sa", "sa.mp3"));
            this.Add(KanaKey.SI, new KanaInfo("s", "shi", "shi.mp3"));
            this.Add(KanaKey.SU, new KanaInfo("d", "su", "su.mp3"));
            this.Add(KanaKey.SE, new KanaInfo("f", "se", "se.mp3"));
            this.Add(KanaKey.SO, new KanaInfo("g", "so", "so.mp3"));

            this.Add(KanaKey.ZA, new KanaInfo("A", "za", "za.mp3"));
            this.Add(KanaKey.ZI, new KanaInfo("S", "ji", "ji_z.mp3"));
            this.Add(KanaKey.ZU, new KanaInfo("D", "zu", "zu.mp3"));
            this.Add(KanaKey.ZE, new KanaInfo("F", "ze", "ze.mp3"));
            this.Add(KanaKey.ZO, new KanaInfo("G", "zo", "zo.mp3"));

            this.Add(KanaKey.SYA, new KanaInfo("s<", "sha", "sha.mp3"));
            this.Add(KanaKey.SYU, new KanaInfo("s>", "shu", "shu.mp3"));
            this.Add(KanaKey.SYO, new KanaInfo("s?", "sho", "sho.mp3"));

            this.Add(KanaKey.ZYA, new KanaInfo("S<", "ja", "ja_jya.mp3"));
            this.Add(KanaKey.ZYU, new KanaInfo("S>", "ju", "ju_jyu.mp3"));
            this.Add(KanaKey.ZYO, new KanaInfo("S?", "jo", "jo_jyo.mp3"));

            this.Add(KanaKey.TA, new KanaInfo("z", "ta", "ta.mp3"));
            this.Add(KanaKey.TI, new KanaInfo("x", "chi", "chi.mp3"));
            this.Add(KanaKey.TU, new KanaInfo("c", "tsu", "tsu.mp3"));
            this.Add(KanaKey.TE, new KanaInfo("v", "te", "te.mp3"));
            this.Add(KanaKey.TO, new KanaInfo("b", "to", "to.mp3"));

            this.Add(KanaKey.DA, new KanaInfo("Z", "da", "da.mp3"));
            this.Add(KanaKey.DI, new KanaInfo("X", "ji", "ji_d.mp3"));
            this.Add(KanaKey.DU, new KanaInfo("C", "zu", "zu_d.mp3"));
            this.Add(KanaKey.DE, new KanaInfo("V", "de", "de.mp3"));
            this.Add(KanaKey.DO, new KanaInfo("B", "do", "do.mp3"));

            this.Add(KanaKey.TYA, new KanaInfo("x<", "cha", "cha.mp3"));
            this.Add(KanaKey.TYU, new KanaInfo("x>", "chu", "chu.mp3"));
            this.Add(KanaKey.TYO, new KanaInfo("x?", "cho", "cho.mp3"));

            this.Add(KanaKey.NA, new KanaInfo("6", "na", "na.mp3"));
            this.Add(KanaKey.NI, new KanaInfo("7", "ni", "ni.mp3"));
            this.Add(KanaKey.NU, new KanaInfo("8", "nu", "nu.mp3"));
            this.Add(KanaKey.NE, new KanaInfo("9", "ne", "ne.mp3"));
            this.Add(KanaKey.NO, new KanaInfo("0", "no", "no.mp3"));

            this.Add(KanaKey.NYA, new KanaInfo("7<", "nya", "nya.mp3"));
            this.Add(KanaKey.NYU, new KanaInfo("7>", "nyu", "nyu.mp3"));
            this.Add(KanaKey.NYO, new KanaInfo("7?", "nyo", "nyo.mp3"));

            this.Add(KanaKey.HA, new KanaInfo("y", "ha", "ha.mp3"));
            this.Add(KanaKey.HI, new KanaInfo("u", "hi", "hi.mp3"));
            this.Add(KanaKey.HU, new KanaInfo("i", "fu", "fu.mp3"));
            this.Add(KanaKey.HE, new KanaInfo("o", "he", "he.mp3"));
            this.Add(KanaKey.HO, new KanaInfo("p", "ho", "ho.mp3"));

            this.Add(KanaKey.BA, new KanaInfo("^", "ba", "ba.mp3"));
            this.Add(KanaKey.BI, new KanaInfo("&", "bi", "bi.mp3"));
            this.Add(KanaKey.BU, new KanaInfo("*", "bu", "bu.mp3"));
            this.Add(KanaKey.BE, new KanaInfo("(", "be", "be.mp3"));
            this.Add(KanaKey.BO, new KanaInfo(")", "bo", "bo.mp3"));

            this.Add(KanaKey.PA, new KanaInfo("H", "pa", "pa.mp3"));
            this.Add(KanaKey.PI, new KanaInfo("J", "pi", "pi.mp3"));
            this.Add(KanaKey.PU, new KanaInfo("K", "pu", "pu.mp3"));
            this.Add(KanaKey.PE, new KanaInfo("L", "pe", "pe.mp3"));
            this.Add(KanaKey.PO, new KanaInfo(":", "po", "po.mp3"));

            this.Add(KanaKey.HYA, new KanaInfo("u<", "hya", "hya.mp3"));
            this.Add(KanaKey.HYU, new KanaInfo("u>", "hyu", "hyu.mp3"));
            this.Add(KanaKey.HYO, new KanaInfo("u?", "hyo", "hyo.mp3"));

            this.Add(KanaKey.BYA, new KanaInfo("&<", "bya", "bya.mp3"));
            this.Add(KanaKey.BYU, new KanaInfo("&>", "byu", "byu.mp3"));
            this.Add(KanaKey.BYO, new KanaInfo("&?", "byo", "byo.mp3"));

            this.Add(KanaKey.PYA, new KanaInfo("J<", "pya", "pya.mp3"));
            this.Add(KanaKey.PYU, new KanaInfo("J>", "pyu", "pyu.mp3"));
            this.Add(KanaKey.PYO, new KanaInfo("J?", "pyo", "pyo.mp3"));

            this.Add(KanaKey.MA, new KanaInfo("h", "ma", "ma.mp3"));
            this.Add(KanaKey.MI, new KanaInfo("j", "mi", "mi.mp3"));
            this.Add(KanaKey.MU, new KanaInfo("k", "mu", "mu.mp3"));
            this.Add(KanaKey.ME, new KanaInfo("l", "me", "me.mp3"));
            this.Add(KanaKey.MO, new KanaInfo(";", "mo", "mo.mp3"));

            this.Add(KanaKey.MYA, new KanaInfo("j<", "mya", "mya.mp3"));
            this.Add(KanaKey.MYU, new KanaInfo("j>", "myu", "myu.mp3"));
            this.Add(KanaKey.MYO, new KanaInfo("j?", "myo", "myo.mp3"));

            this.Add(KanaKey.YA, new KanaInfo(",", "ya", "ya.mp3"));
            this.Add(KanaKey.YU, new KanaInfo(".", "yu", "yu.mp3"));
            this.Add(KanaKey.YO, new KanaInfo(@"/", "yo", "yo.mp3"));

            this.Add(KanaKey.RA, new KanaInfo("-", "ra", "ra.mp3"));
            this.Add(KanaKey.RI, new KanaInfo("=", "ri", "ri.mp3"));
            this.Add(KanaKey.RU, new KanaInfo("[", "ru", "ru.mp3"));
            this.Add(KanaKey.RE, new KanaInfo("]", "re", "re.mp3"));
            this.Add(KanaKey.RO, new KanaInfo(@"\", "ro", "ro.mp3"));

            this.Add(KanaKey.RYA, new KanaInfo("=<", "rya", "rya.mp3"));
            this.Add(KanaKey.RYU, new KanaInfo("=>", "ryu", "ryu.mp3"));
            this.Add(KanaKey.RYO, new KanaInfo(@"=?", "ryo", "ryo.mp3"));

            this.Add(KanaKey.WA, new KanaInfo("'", "wa", "wa.mp3"));
            this.Add(KanaKey.WO, new KanaInfo("n", "o", "o_w.mp3"));

            this.Add(KanaKey.N, new KanaInfo("m", "n", "n.mp3"));

            this.Add(KanaKey.DOUBLE, new KanaInfo("+", "", ""));
            this.Add(KanaKey.LONG, new KanaInfo("_", "", ""));
            this.Add(KanaKey.A_SMALL, new KanaInfo("Y", "a", ""));
            this.Add(KanaKey.I_SMALL, new KanaInfo("M", "i", ""));
            this.Add(KanaKey.U_SMALL, new KanaInfo("|", "u", ""));
            this.Add(KanaKey.E_SMALL, new KanaInfo("U", "e", ""));
            this.Add(KanaKey.O_SMALL, new KanaInfo("N", "o", ""));
            this.Add(KanaKey.COMMA, new KanaInfo("I", ",", ""));
            this.Add(KanaKey.FULLSTOP, new KanaInfo("O", ".", ""));
        }
    }
}