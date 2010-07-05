﻿using System;
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

namespace Arbaureal.KanaDoIT.Views.Katakana
{
    public class KatakanaBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Katakana; }
        }

        public static Color StaticMenuColour
        {
            get { return Color.FromArgb(255, 183, 255, 179); }
        }

        public Color MenuColour
        {
            get { return StaticMenuColour; }
        }

        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Introduction", "/Katakana/Introduction"));
            listTopics.Add(new Topic("Select Characters", "/Katakana/SelectCharacters"));
            listTopics.Add(new Topic(@"Read & Listen", "/Katakana/ReadnListen"));
            listTopics.Add(new Topic("Write", "/Katakana/Write"));
            listTopics.Add(new Topic("Reading Challenge", "/Katakana/ReadingChallenge"));
            listTopics.Add(new Topic("Writing Challenge", "/Katakana/WritingChallenge"));
            listTopics.Add(new Topic("Listening Challenge", "/Katakana/ListeningChallenge"));

            return listTopics;
        }

        public static ListKanaKeys ListKanaKeys;

        static KatakanaBaseView()
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
