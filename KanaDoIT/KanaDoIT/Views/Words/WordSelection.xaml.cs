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
    public partial class WordSelection : WordsBaseView
    {
        public WordSelection()
        {
            InitializeComponent();

            WordCategoriesListBox.ItemsSource = KanaDictionary.WordCategories;
            WordCategoriesListBox.DisplayMemberPath = "Title";
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If we have a previous selection, restore it.
            if (HasSelection)
            {
                foreach (WordCategory WordCategory in ListSelectedWordCategories)
                {
                    WordCategoriesListBox.SelectedItems.Add(WordCategory);
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ListSelectedWordCategories.Clear();
            foreach (WordCategory WC in WordCategoriesListBox.SelectedItems)
            {
                AddWordCategory(WC);
            }

            base.OnNavigatedFrom(e);
        }
    }
}
