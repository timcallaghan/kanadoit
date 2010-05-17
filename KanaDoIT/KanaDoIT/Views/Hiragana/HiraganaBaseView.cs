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

namespace Arbaureal.KanaDoIT.Views.Hiragana
{
    public class HiraganaBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Hiragana; }
        }

        public Color MenuColour
        {
            get { return Color.FromArgb(255, 0, 0, 255); }
        }
        
        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Introduction", "/Hiragana/Introduction"));
            listTopics.Add(new Topic(@"Read & Listen", "/Hiragana/ReadnListen"));
            listTopics.Add(new Topic("Write", "/Hiragana/Write"));
            listTopics.Add(new Topic("Basic Challenge", "/Hiragana/BasicChallenge"));
            listTopics.Add(new Topic("Reading Challenge", "/Hiragana/ReadingChallenge"));
            listTopics.Add(new Topic("Listening Challenge", "/Hiragana/ListeningChallenge"));

            return listTopics;
        }        
    }
}
