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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Arbaureal.KanaDoIT.BaseResources;
using Arbaureal.KanaDoIT.Views.Hiragana;
using Arbaureal.KanaDoIT.Views.Katakana;
using Arbaureal.KanaDoIT.Views.Nouns;
using Arbaureal.KanaDoIT.Views.Time;
using Arbaureal.KanaDoIT.Views.Words;
using Arbaureal.KanaDoIT.Views.Phrases;

namespace Arbaureal.KanaDoIT
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {            
            SetBackgroundColor(HiraganLink, HiraganaBaseView.StaticMenuColour);
            SetBackgroundColor(KatakanaLink, KatakanaBaseView.StaticMenuColour);
            SetBackgroundColor(NounsLink, NounsBaseView.StaticMenuColour);
            SetBackgroundColor(TimeLink, TimeBaseView.StaticMenuColour);
            SetBackgroundColor(WordsLink, WordsBaseView.StaticMenuColour);
            SetBackgroundColor(PhrasesLink, PhrasesBaseView.StaticMenuColour);
        }

        private void SetBackgroundColor(HyperlinkButton btn, Color Color)
        {
            LinearGradientBrush gb = new LinearGradientBrush();
            GradientStop start = new GradientStop();
            start.Color = Colors.White;
            start.Offset = 0.0;
            GradientStop end = new GradientStop();
            end.Color = Color;
            end.Offset = 0.5;
            gb.GradientStops.Add(start);
            gb.GradientStops.Add(end);
            gb.StartPoint = new Point(0.5, 0.0);
            gb.EndPoint = new Point(0.5, 1.0);
            btn.Background = gb;
        }
    }
}