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

namespace Arbaureal.KanaDoIT.Views.Hiragana
{
    public partial class ReadnListen : HiraganaBaseView
    {
        private int currentIndex = 0;

        public ReadnListen()
        {
            InitializeComponent();
            CheckListOfKanaKeys();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            kanaPlaceholder.FontFamily =  BaseResources.KanaFont.HiraganaFont;
            kanaPlaceholder.FontSize = 200;

            kanaPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].FontCode;
            romajiPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].Romaji;
            SoundPlayer.Source = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].SoundFilePath;
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < ListKanaKeys.Count - 1)
            {
                ++currentIndex;
            }
            else
            {
                currentIndex = 0;
            }

            kanaPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].FontCode;
            romajiPlaceholder.Text = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].Romaji;

            SoundPlayer.Stop();
            SoundPlayer.Source = DictionaryKanaInfo.Instance[ListKanaKeys[currentIndex]].SoundFilePath;
        }

        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer.Stop();
            SoundPlayer.Play();
        }
    }
}
