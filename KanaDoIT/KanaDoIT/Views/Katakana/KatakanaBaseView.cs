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

namespace Arbaureal.KanaDoIT.Views.Katakana
{
    public class KatakanaBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Katakana; }
        }

        public Color MenuColour
        {
            get { return Color.FromArgb(255, 0, 255, 0); }
        }

        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Introduction", "/Katakana/Introduction"));
            listTopics.Add(new Topic(@"Read & Listen", "/Katakana/ReadnListen"));
            listTopics.Add(new Topic("Write", "/Katakana/Write"));
            listTopics.Add(new Topic("Basic Challenge", "/Katakana/BasicChallenge"));
            listTopics.Add(new Topic("Reading Challenge", "/Katakana/ReadingChallenge"));
            listTopics.Add(new Topic("Listening Challenge", "/Katakana/ListeningChallenge"));

            return listTopics;
        }
    }
}
