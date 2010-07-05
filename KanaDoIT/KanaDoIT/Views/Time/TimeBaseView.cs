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

namespace Arbaureal.KanaDoIT.Views.Time
{
    public class TimeBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Time; }
        }

        public static Color StaticMenuColour
        {
            get { return Color.FromArgb(255, 253, 255, 152); }
        }

        public Color MenuColour
        {
            get { return StaticMenuColour; }
        }

        public List<Topic> GetListOfTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            listTopics.Add(new Topic("Time", "/Time/Time"));
            //listTopics.Add(new Topic(@"Read & Listen", "/Time/ReadnListen"));
            //listTopics.Add(new Topic("Write", "/Time/Write"));
            //listTopics.Add(new Topic("Basic Challenge", "/Time/BasicChallenge"));
            //listTopics.Add(new Topic("Reading Challenge", "/Time/ReadingChallenge"));
            //listTopics.Add(new Topic("Listening Challenge", "/Time/ListeningChallenge"));

            return listTopics;
        }
    }
}
