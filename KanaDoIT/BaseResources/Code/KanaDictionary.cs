using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Arbaureal.KanaDoIT.BaseResources
{
    public class WordCategory
    {
        public int ID { get; private set; }
        public string Title { get; private set; }

        public WordCategory(int WordCategoryID, string Title)
        {
            this.ID = WordCategoryID;
            this.Title = Title;
        }
    }

    // Singleton list of WordCategories
    public sealed class WordCategories : List<WordCategory>
    {
        static readonly WordCategories instance = new WordCategories();

        public static WordCategories Instance
        {
            get
            {
                return instance;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static WordCategories()
        {
        }

        WordCategories()
        {
        }

        public WordCategory GetWordCategory(int ID)
        {
            return this.First(wc => wc.ID == ID);
        }
    }

    public class Word
    {
        private List<KanaCharInfo> KanaWord;
        public string EnglishWord { get; private set; }
        public string Romaji;
        public List<WordCategory> CategoryAssociations { get; private set; }

        public Word(string strEnglishWord, List<KanaCharInfo> listCharInfo, List<WordCategory> CategoryAssociations, string Romaji)
        {
            EnglishWord = strEnglishWord;
            KanaWord = listCharInfo;
            this.CategoryAssociations = CategoryAssociations;
            this.Romaji = Romaji;
        }

        public TextBlock GetWordKana()
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

        public List<Run> GetWordKana(double FontSize)
        {
            List<Run> listTextRuns = new List<Run>();

            foreach (KanaCharInfo charInfo in KanaWord)
            {
                Run textRun = new Run();
                textRun.FontFamily = charInfo.KanaFont;
                textRun.FontSize = FontSize;
                textRun.Text = DictionaryKanaInfo.Instance[charInfo.Kana].FontCode;
                listTextRuns.Add(textRun);
            }

            return listTextRuns;
        }
    }

    // Singleton dictionary of words
    public sealed class KanaDictionary : Dictionary<int, Word>
    {
        static readonly KanaDictionary instance = new KanaDictionary();

        public static KanaDictionary Instance
        {
            get
            {
                return instance;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static KanaDictionary()
        {
        }

        public static WordCategories WordCategories
        {
            get
            {
                return WordCategories.Instance;
            }
        }

        public List<int> GetWordKeysForCategory(WordCategory WC)
        {
            return this.Where(KVP => KVP.Value.CategoryAssociations.Contains(WC)).Select(KVP => KVP.Key).ToList();
        }

        KanaDictionary()
        {
            XDocument document = XDocument.Load("/BaseResources;component/Dictionary/KanaDictionary.xml");

            int DictionaryKey = 0;

            // Set up all the categories
            WordCategories WordCategories = WordCategories.Instance;
            foreach (XElement element in document.Element("KanaDictionary").Element("WordCategories").Elements())
            {
                int ID = Int32.Parse(element.Element("ID").Value);
                string Title = element.Element("Title").Value;
                WordCategories.Add(new WordCategory(ID, Title));
            }

            // Parse the words in the dictionary
            foreach (XElement Word in document.Element("KanaDictionary").Element("Words").Elements())
            {
                // Get the categories that the word subscribes to
                List<WordCategory> CategoryAssociations = new List<WordCategory>();
                foreach (XElement Category in Word.Element("Categories").Elements())
                {
                    int ID = Int32.Parse(Category.Value);
                    CategoryAssociations.Add(WordCategories.GetWordCategory(ID));
                }

                string EnglishWord = Word.Element("EnglishWord").Value;
                string Romaji = Word.Element("Romaji").Value;

                List<KanaCharInfo> listCharInfo = new List<KanaCharInfo>();
                foreach (XElement KanaChar in Word.Elements("ListKanaChars").Elements())
                {
                    KanaKey kanakey = (KanaKey)Enum.Parse(typeof(KanaKey), KanaChar.Element("KanaKey").Value, false);
                    KanaType kanatype = (KanaType)Enum.Parse(typeof(KanaType), KanaChar.Element("FontFamily").Value, false);
                    listCharInfo.Add(new KanaCharInfo(kanakey, KanaFont.GetKanaFont(kanatype)));
                }

                Word word = new Word(EnglishWord, listCharInfo, CategoryAssociations, Romaji);
                this[DictionaryKey++] = word;
            }
        }
    }
}