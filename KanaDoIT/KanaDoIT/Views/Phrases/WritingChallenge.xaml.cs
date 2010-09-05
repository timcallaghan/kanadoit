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

using Arbaureal.KanaDoIT.BaseResources;
using System.Windows.Ink;

namespace Arbaureal.KanaDoIT.Views.Phrases
{
    public partial class WritingChallenge : PhrasesBaseView
    {
        private ListKanaKeys listKanaKeysToTest;
        private KanaKey currentKananKey;

        public WritingChallenge()
        {
            InitializeComponent();
            //CheckListOfKanaKeys();
            SetBoundary();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //kanaPlaceholder.FontFamily = BaseResources.KanaFont.PhrasesFont;
            //kanaPlaceholder.FontSize = 200;
            //kanaPlaceholder.Foreground = new SolidColorBrush(Colors.Gray);

            //listKanaKeysToTest = new ListKanaKeys();
            //foreach (KanaKey key in ListKanaKeys)
            //{
            //    listKanaKeysToTest.Add(key);
            //}

            //currentKananKey = listKanaKeysToTest.GetRandomKey().Value;
            //kanaPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].FontCode;
            //kanaPlaceholder.Opacity = 0.0;
            //romajiPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].Romaji;
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            listKanaKeysToTest.Remove(currentKananKey);
            MyIP.Strokes.Clear();

            Nullable<KanaKey> key = listKanaKeysToTest.GetRandomKey();
            if (key.HasValue)
            {
                currentKananKey = key.Value;
                kanaPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].FontCode;
                kanaPlaceholder.Opacity = 0.0;
                romajiPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].Romaji;
            }
            else
            {
                // The user has completed the list
                txtInfo.Text = "Congratulations!  You have successfully written all of the selected Phrases.";
                kanaPlaceholder.Visibility = System.Windows.Visibility.Collapsed;
                romajiPlaceholder.Visibility = System.Windows.Visibility.Collapsed;
                btnCycle.Visibility = System.Windows.Visibility.Collapsed;
                btnShowAnswer.Visibility = System.Windows.Visibility.Collapsed;
                btnUndo.Visibility = System.Windows.Visibility.Collapsed;
                MyIP.Visibility = System.Windows.Visibility.Collapsed;
            }
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
            myDa.Color = Color.FromArgb(200, 255, 0, 0);
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

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (MyIP.Strokes.Count > 0)
            {
                MyIP.Strokes.RemoveAt(MyIP.Strokes.Count - 1);
            }
        }

        private void btnShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            kanaPlaceholder.Opacity = 1.0;
        }

    }
}
