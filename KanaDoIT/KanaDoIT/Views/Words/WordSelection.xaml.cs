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
using Arbaureal.ArbaurealUILib.DataSources;
using System.Collections.ObjectModel;

namespace Arbaureal.KanaDoIT.Views.Words
{
    public partial class WordSelection : WordsBaseView
    {
        private List<WordCategory> ListSelectedItems;

        public WordSelection()
        {
            InitializeComponent();

            ListSelectedItems = new List<WordCategory>();
            ObservableCollection<HierarchicalDataSource<WordCategory>> Source = new ObservableCollection<HierarchicalDataSource<WordCategory>>();
            HierarchicalDataSource<WordCategory> hSource = new HierarchicalDataSource<WordCategory>(null) { Name = "All Categories", Children = new List<HierarchicalDataSource<WordCategory>>() };
            hSource.AfterChecked += new EventHandler(AfterChecked);
            foreach (WordCategory WC in KanaDictionary.WordCategories)
            {
                bool IsChecked = false;
                // If we have a previous selection, restore it.
                if (HasSelection && ListSelectedWordCategories.Contains(WC))
                {
                    ListSelectedItems.Add(WC);
                    IsChecked = true;
                }
                HierarchicalDataSource<WordCategory> Child = new HierarchicalDataSource<WordCategory>(WC) { Name = WC.Title, Parent = hSource, IsChecked = IsChecked };
                Child.AfterChecked += new EventHandler(AfterChecked);
                hSource.Children.Add(Child);
            }

            if (HasSelection)
            {
                if (ListSelectedWordCategories.Count == KanaDictionary.WordCategories.Count)
                {
                    hSource.IsChecked = true;
                }
                else
                {
                    hSource.IsChecked = null;
                }
            }
            else
            {
                hSource.IsChecked = false;
            }

            Source.Add(hSource);
            WordCategoriesTreeView.CheckedTreeView.ItemsSource = Source;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ListSelectedWordCategories.Clear();
            foreach (WordCategory WC in ListSelectedItems)
            {
                AddWordCategory(WC);
            }

            base.OnNavigatedFrom(e);
        }

        void AfterChecked(object sender, EventArgs e)
        {
            HierarchicalDataSource<WordCategory> TreeNode = sender as HierarchicalDataSource<WordCategory>;
            if (TreeNode != null && TreeNode.DataItem != null)
            {
                if (TreeNode.IsChecked.HasValue && TreeNode.IsChecked.Value)
                {
                    AddOrRemoveWordCategory(TreeNode.DataItem, true);
                }
                else
                {
                    AddOrRemoveWordCategory(TreeNode.DataItem, false); ;
                }
            }
        }

        private void AddOrRemoveWordCategory(WordCategory WC, bool Include)
        {
            if (Include && !ListSelectedItems.Contains(WC))
            {
                ListSelectedItems.Add(WC);
            }
            else
            {
                ListSelectedItems.Remove(WC);
            }
        }
    }
}
