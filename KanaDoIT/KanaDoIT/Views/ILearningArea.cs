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

namespace Arbaureal.KanaDoIT.Views
{
    // Types of learning areas available in KanaDoIT
    public enum LearningArea
    {
        Hiragana,
        Katakana,
        Nouns,
        Time
    }

    // A topic that is contained in a learning area
    public class Topic
    {
        public string Name { get; set; }
        public string NavigateUri { get; set; }

        public Topic(string Name, string NavigateUri)
        {
            this.Name = Name;
            this.NavigateUri = NavigateUri;
        }
    }

    // Implement this interface to allow automatic integration of the learning area
    // with the navigation system in KanaDoIT.
    public interface ILearningArea
    {
        // The learning area type
        LearningArea LearningArea { get; }

        // The background colour associated with the learning area
        Color MenuColour { get; }

        // Provide a list of topics in the learning area for inclusion in the menu
        List<Topic> GetListOfTopics();
    }
}
