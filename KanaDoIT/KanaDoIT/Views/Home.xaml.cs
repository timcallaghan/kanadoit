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
            LinearGradientBrush gb = new LinearGradientBrush();
            GradientStop start = new GradientStop();
            start.Color = Colors.White;
            start.Offset = 0.0;
            GradientStop end = new GradientStop();
            end.Color = HiraganaBaseView.StaticMenuColour;
            end.Offset = 0.5;
            gb.GradientStops.Add(start);
            gb.GradientStops.Add(end);
            gb.StartPoint = new Point(0.5, 0.0);
            gb.EndPoint = new Point(0.5, 1.0);
            HiraganLink.Background = gb;

            gb = new LinearGradientBrush();
            start = new GradientStop();
            start.Color = Colors.White;
            start.Offset = 0.0;
            end = new GradientStop();
            end.Color = KatakanaBaseView.StaticMenuColour;
            end.Offset = 0.5;
            gb.GradientStops.Add(start);
            gb.GradientStops.Add(end);
            gb.StartPoint = new Point(0.5, 0.0);
            gb.EndPoint = new Point(0.5, 1.0);
            KatakanaLink.Background = gb;

            gb = new LinearGradientBrush();
            start = new GradientStop();
            start.Color = Colors.White;
            start.Offset = 0.0;
            end = new GradientStop();
            end.Color = NounsBaseView.StaticMenuColour;
            end.Offset = 0.5;
            gb.GradientStops.Add(start);
            gb.GradientStops.Add(end);
            gb.StartPoint = new Point(0.5, 0.0);
            gb.EndPoint = new Point(0.5, 1.0);
            NounsLink.Background = gb;

            gb = new LinearGradientBrush();
            start = new GradientStop();
            start.Color = Colors.White;
            start.Offset = 0.0;
            end = new GradientStop();
            end.Color = TimeBaseView.StaticMenuColour;
            end.Offset = 0.5;
            gb.GradientStops.Add(start);
            gb.GradientStops.Add(end);
            gb.StartPoint = new Point(0.5, 0.0);
            gb.EndPoint = new Point(0.5, 1.0);
            TimeLink.Background = gb;
        }
    }
}