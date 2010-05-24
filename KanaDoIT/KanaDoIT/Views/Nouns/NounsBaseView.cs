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

namespace Arbaureal.KanaDoIT.Views.Nouns
{
    public class NounsBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Nouns; }
        }

        public static Color StaticMenuColour
        {
            get { return Color.FromArgb(255, 200, 0, 200); }
        }

        public Color MenuColour
        {
            get { return StaticMenuColour; }
        }

        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Nouns", "/Nouns/Nouns"));
            //listTopics.Add(new Topic(@"Read & Listen", "/Nouns/ReadnListen"));
            //listTopics.Add(new Topic("Write", "/Nouns/Write"));
            //listTopics.Add(new Topic("Basic Challenge", "/Nouns/BasicChallenge"));
            //listTopics.Add(new Topic("Reading Challenge", "/Nouns/ReadingChallenge"));
            //listTopics.Add(new Topic("Listening Challenge", "/Nouns/ListeningChallenge"));

            return listTopics;
        }
    }
}
