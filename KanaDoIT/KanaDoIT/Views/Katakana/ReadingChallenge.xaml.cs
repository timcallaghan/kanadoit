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

using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Presenter;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View;
using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Katakana
{
    public partial class ReadingChallenge : KatakanaBaseView
    {
        private IKanaboardModel kanaboardModel;
        private ListKanaKeys listKanaKeysToTest;
        private KanaKey currentKananKey;

        public ReadingChallenge()
        {
            InitializeComponent();
            CheckListOfKanaKeys();

            kanaboardModel = Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model.Kanaboard.Create(KanaType.Romaji);
            KanaboardPresenter presenter = new KanaboardPresenter(this.Kanaboard, kanaboardModel);
            kanaboardModel.KeyPressed += new EventHandler<KanaDoIT.Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs>(kanaboardModel_KeyPressed);
        }

        void kanaboardModel_KeyPressed(object sender, Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs e)
        {
            if (e.KanaKey == currentKananKey)
            {
                listKanaKeysToTest.Remove(currentKananKey);

                Nullable<KanaKey> key = listKanaKeysToTest.GetRandomKey();
                if (key.HasValue)
                {
                    currentKananKey = key.Value;
                    txtInfo.Text = "Correct!  Well done.";
                    kanaPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].FontCode;
                }
                else
                {
                    // The user has completed the list
                    txtInfo.Text = "Congratulations!  You have successfully identified all of the selected Katakana.";
                    kanaPlaceholder.Visibility = System.Windows.Visibility.Collapsed;
                    Kanaboard.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
            {
                txtInfo.Text = "Incorrect!  Try again.";
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            kanaboardModel.KanaType = KanaType.Romaji;
            kanaPlaceholder.FontFamily = BaseResources.KanaFont.KatakanaFont;
            kanaPlaceholder.FontSize = 100;

            listKanaKeysToTest = new ListKanaKeys();
            foreach (KanaKey key in ListKanaKeys)
            {
                listKanaKeysToTest.Add(key);
            }

            currentKananKey = listKanaKeysToTest.GetRandomKey().Value;
            kanaPlaceholder.Text = DictionaryKanaInfo.Instance[currentKananKey].FontCode;
        }
    }
}
