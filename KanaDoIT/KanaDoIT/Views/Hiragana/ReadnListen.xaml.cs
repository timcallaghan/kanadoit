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

namespace Arbaureal.KanaDoIT.Views.Hiragana
{
    public partial class ReadnListen : HiraganaBaseView
    {
        private Random random;
        private BaseResources.DictionaryKanaInfo dictKana;
        private BaseResources.KanaKey currentKanaKey;

        public ReadnListen()
        {
            InitializeComponent();
            
            random = new Random();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //((MainPage)App.Current.RootVisual).
            dictKana = new BaseResources.DictionaryKanaInfo();

            kanaPlaceholder.FontFamily = BaseResources.DictionaryKanaInfo.HiraganaFont;
            kanaPlaceholder.FontSize = 200;

            currentKanaKey = BaseResources.KanaKey.A;

            kanaPlaceholder.Text = dictKana[currentKanaKey].FontCode;
            romajiPlaceholder.Text = dictKana[currentKanaKey].Romaji;
            SoundPlayer.Source = dictKana[currentKanaKey].SoundFilePath;
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            currentKanaKey = (BaseResources.KanaKey)random.Next((int)BaseResources.KanaKey.N + 1);

            kanaPlaceholder.Text = dictKana[currentKanaKey].FontCode;
            romajiPlaceholder.Text = dictKana[currentKanaKey].Romaji;

            SoundPlayer.Stop();
            SoundPlayer.Source = dictKana[currentKanaKey].SoundFilePath;
        }

        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer.Stop();
            SoundPlayer.Play();
        }
    }
}
