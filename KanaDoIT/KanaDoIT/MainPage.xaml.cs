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

using Arbaureal.KanaDoIT.Views;

namespace Arbaureal.KanaDoIT
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content != null)
            {
                foreach (UIElement child in LinksStackPanel.Children)
                {
                    HyperlinkButton hb = child as HyperlinkButton;
                    if (hb != null && hb.NavigateUri != null)
                    {
                        if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                        {
                            VisualStateManager.GoToState(hb, "ActiveLink", true);
                        }
                        else
                        {
                            VisualStateManager.GoToState(hb, "InactiveLink", true);
                        }
                    }
                }

                if (e.Content is ILearningArea)
                {
                    ILearningArea learningArea = e.Content as ILearningArea;
                    LinearGradientBrush gb = new LinearGradientBrush();
                    GradientStop start = new GradientStop();
                    start.Color = Colors.White;
                    start.Offset = 0.0;
                    GradientStop end = new GradientStop();
                    end.Color = learningArea.MenuColour;
                    end.Offset = 0.5;
                    gb.GradientStops.Add(start);
                    gb.GradientStops.Add(end);
                    gb.StartPoint = new Point(0.5, 0.0);
                    gb.EndPoint = new Point(0.5, 1.0);
                    OuterContentBorder.Background = gb;
                    SubMenuColDef.Width = new GridLength(200);

                    TopicMenu.Children.Clear();
                    List<Topic> listTopics = learningArea.GetListOfTopics();
                    foreach (Topic topic in listTopics)
                    {
                        HyperlinkButton hlButton = new HyperlinkButton();
                        hlButton.NavigateUri = new Uri(topic.NavigateUri, UriKind.Relative);
                        hlButton.TargetName = "ContentFrame";
                        hlButton.Content = topic.Name;
                        //hlButton.Style = (Style)Application.Current.Resources["LinkStyle"];

                        LinearGradientBrush hlgb = new LinearGradientBrush();
                        GradientStop hlstart = new GradientStop();
                        hlstart.Color = Colors.White;
                        hlstart.Offset = 0.0;
                        GradientStop hlend = new GradientStop();
                        hlend.Color = Colors.White;
                        hlend.Offset = 1.0;
                        GradientStop hlMid = new GradientStop();
                        hlMid.Color = learningArea.MenuColour;
                        hlMid.Offset = 0.5;
                        hlgb.GradientStops.Add(hlstart);
                        hlgb.GradientStops.Add(hlMid);
                        hlgb.GradientStops.Add(hlend);
                        hlgb.StartPoint = new Point(0.5, 0.0);
                        hlgb.EndPoint = new Point(0.5, 1.0);

                        hlButton.Background = hlgb;
                        hlButton.FontSize = 16;
                        hlButton.Foreground = new SolidColorBrush(Colors.Black);
                        TopicMenu.Children.Add(hlButton);
                    }
                }
                else
                {
                    OuterContentBorder.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    SubMenuColDef.Width = new GridLength(0);
                }
            }
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
        }
    }
}