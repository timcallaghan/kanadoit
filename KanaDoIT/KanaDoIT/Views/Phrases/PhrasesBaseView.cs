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

namespace Arbaureal.KanaDoIT.Views.Phrases
{
    public class PhrasesBaseView : Page, ILearningArea
    {
        public LearningArea LearningArea
        {
            get { return LearningArea.Phrases; }
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

            listTopics.Add(new Topic("Introduction", "/Phrases/Introduction"));
            listTopics.Add(new Topic("Phrase Selection", "/Phrases/PhraseSelection"));
            listTopics.Add(new Topic("Read", "/Phrases/Read"));
            listTopics.Add(new Topic("Write", "/Phrases/Write"));
            listTopics.Add(new Topic("Reading Challenge", "/Phrases/ReadingChallenge"));
            listTopics.Add(new Topic("Writing Challenge", "/Phrases/WritingChallenge"));

            return listTopics;
        }
    }
}
