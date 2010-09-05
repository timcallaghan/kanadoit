using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Words
{
    public partial class Read : WordsBaseView
    {
        private int currentCategoryIndex = 0;
        private List<int> WordsInCategory = null;
        private int CurrentWordIndex = 0;

        public Read()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            KanaDictionary dict = KanaDictionary.Instance;
            WordsInCategory = KanaDictionary.Instance.GetWordKeysForCategory(ListSelectedWordCategories[currentCategoryIndex]);
            CurrentWordIndex = 0;

            PopulateDisplay();
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentWordIndex < WordsInCategory.Count - 1)
            {
                ++CurrentWordIndex;
            }
            else
            {
                CurrentWordIndex = 0;
                if (currentCategoryIndex < ListSelectedWordCategories.Count - 1)
                {
                    ++currentCategoryIndex;
                }
                else
                {
                    currentCategoryIndex = 0;
                }
                WordsInCategory = KanaDictionary.Instance.GetWordKeysForCategory(ListSelectedWordCategories[currentCategoryIndex]);
            }

            PopulateDisplay();
        }

        private void PopulateDisplay()
        {
            kanaPlaceholder.Inlines.Clear();
            romajiPlaceholder.Inlines.Clear();
            englishPlaceholder.Inlines.Clear();
            try
            {
                Word Word = KanaDictionary.Instance[WordsInCategory[CurrentWordIndex]];
                foreach (Run textRun in Word.GetWordKana(60.0))
                {
                    kanaPlaceholder.Inlines.Add(textRun);
                }
                romajiPlaceholder.Inlines.Add(Word.Romaji);
                englishPlaceholder.Inlines.Add(Word.EnglishWord);
            }
            catch (Exception)
            {
            }
        }
    }
}
