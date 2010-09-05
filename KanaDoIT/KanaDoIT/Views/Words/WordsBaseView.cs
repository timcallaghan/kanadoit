using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Words
{
    public class WordsBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Words; }
        }

        public static Color StaticMenuColour
        {
            get { return Color.FromArgb(255, 237, 147, 111); }
        }

        public Color MenuColour
        {
            get { return StaticMenuColour; }
        }

        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Introduction", "/Words/Introduction"));
            listTopics.Add(new Topic("Word Selection", "/Words/WordSelection"));
            listTopics.Add(new Topic("Read", "/Words/Read"));
            listTopics.Add(new Topic("Write", "/Words/Write"));
            listTopics.Add(new Topic("Reading Challenge", "/Words/ReadingChallenge"));
            listTopics.Add(new Topic("Writing Challenge", "/Words/WritingChallenge"));

            return listTopics;
        }

        private static List<WordCategory> ListSelectedWordCategoriesInternal;
        public static List<WordCategory> ListSelectedWordCategories
        {
            get
            {
                if (ListSelectedWordCategoriesInternal.Count == 0)
                {
                    // The user hasn't selected any categories to learn so default
                    // to adding all categories
                    ListSelectedWordCategoriesInternal.AddRange(KanaDictionary.WordCategories);
                }

                return ListSelectedWordCategoriesInternal;
            }
        }

        public bool HasSelection
        {
            get 
            {
                return ListSelectedWordCategoriesInternal.Count > 0;
            }
        }

        public void AddWordCategory(WordCategory WordCategory)
        {
            if (!ListSelectedWordCategoriesInternal.Contains(WordCategory))
            {
                ListSelectedWordCategoriesInternal.Add(WordCategory);
            }
        }

        static WordsBaseView()
        {
            ListSelectedWordCategoriesInternal = new List<WordCategory>();
        }
    }
}
