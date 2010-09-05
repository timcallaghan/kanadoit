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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Ink;

using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Words
{
    public partial class Write : WordsBaseView
    {
        private int currentIndex = 0;

        public Write()
        {
            InitializeComponent();
            SetBoundary();
            //CheckListOfKanaKeys();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //kanaPlaceholder.FontFamily = BaseResources.KanaFont.WordsFont;
            //kanaPlaceholder.FontSize = 200;
            //kanaPlaceholder.Foreground = new SolidColorBrush(Colors.Gray);

            //kanaPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].FontCode;
            //romajiPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].Romaji;
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            //if (currentIndex < ListKanaKeys.Count - 1)
            //{
            //    ++currentIndex;
            //}
            //else
            //{
            //    currentIndex = 0;
            //}

            //kanaPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].FontCode;
            //romajiPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].Romaji;
            //MyIP.Strokes.Clear();
        }

        Stroke NewStroke;

        //A new stroke object named MyStroke is created. MyStroke is added to the StrokeCollection of the InkPresenter named MyIP
        private void MyIP_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            MyIP.CaptureMouse();
            StylusPointCollection MyStylusPointCollection = new StylusPointCollection();
            MyStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(MyIP));
            NewStroke = new Stroke(MyStylusPointCollection);
            DrawingAttributes myDa = new DrawingAttributes();
            myDa.Color = Color.FromArgb(200,255,0,0);
            myDa.Width = 10;
            myDa.Height = 10;
            NewStroke.DrawingAttributes = myDa;
            MyIP.Strokes.Add(NewStroke);
        }

        //StylusPoint objects are collected from the MouseEventArgs and added to MyStroke. 
        private void MyIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewStroke != null)
                NewStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(MyIP));
        }

        //MyStroke is completed
        private void MyIP_LostMouseCapture(object sender, MouseEventArgs e)
        {
            NewStroke = null;

        }

        //Set the Clip property of the inkpresenter so that the strokes
        //are contained within the boundary of the inkpresenter
        private void SetBoundary()
        {
            RectangleGeometry MyRectangleGeometry = new RectangleGeometry();
            MyRectangleGeometry.Rect = new Rect(0, 0, MyIP.ActualWidth, MyIP.ActualHeight);
            MyIP.Clip = MyRectangleGeometry;
            MyIP.Background = new SolidColorBrush(Color.FromArgb(50, 150, 150, 150));
        }

        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            MyIP.Strokes.Clear();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (MyIP.Strokes.Count > 0)
            {
                MyIP.Strokes.RemoveAt(MyIP.Strokes.Count - 1);
            }
        }
    }
}
