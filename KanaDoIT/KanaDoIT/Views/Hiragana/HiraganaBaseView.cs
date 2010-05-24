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

using Arbaureal.KanaDoIT.Views;
using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Hiragana
{
    public class HiraganaBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Hiragana; }
        }

        public static Color StaticMenuColour
        {
            get { return Color.FromArgb(255, 0, 0, 255); }
        }

        public Color MenuColour
        {
            get { return StaticMenuColour; }
        }
        
        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Introduction", "/Hiragana/Introduction"));
            listTopics.Add(new Topic("Select Characters", "/Hiragana/SelectCharacters"));
            listTopics.Add(new Topic(@"Read & Listen", "/Hiragana/ReadnListen"));
            listTopics.Add(new Topic("Write", "/Hiragana/Write"));
            listTopics.Add(new Topic("Reading Challenge", "/Hiragana/ReadingChallenge"));
            listTopics.Add(new Topic("Writing Challenge", "/Hiragana/WritingChallenge"));
            listTopics.Add(new Topic("Listening Challenge", "/Hiragana/ListeningChallenge"));

            return listTopics;
        }

        public static ListKanaKeys ListKanaKeys;

        static HiraganaBaseView()
        {
            ListKanaKeys = new ListKanaKeys();
        }

        public void CheckListOfKanaKeys()
        {
            if (ListKanaKeys.Count == 0)
            {
                // The user hasn't selected any keys to learn so default
                // to adding all keys
                for (int KanaKeyEnumVal = (int)KanaKey.A; KanaKeyEnumVal <= (int)KanaKey.N; ++KanaKeyEnumVal)
                {
                    ListKanaKeys.Add((KanaKey)KanaKeyEnumVal);
                }
            }
        }
    }
}
