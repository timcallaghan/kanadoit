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

namespace Arbaureal.KanaDoIT.Views.Hiragana
{
    public partial class ListeningChallenge : HiraganaBaseView
    {
        private IKanaboardModel kanaboardModel;
        private DictionaryKanaInfo dictKanaInfo;

        public ListeningChallenge()
        {
            InitializeComponent();

            kanaboardModel = Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model.Kanaboard.Create(KanaType.Hiragana);
            KanaboardPresenter presenter = new KanaboardPresenter(this.Kanaboard, kanaboardModel);
            kanaboardModel.KeyPressed += new EventHandler<KanaDoIT.Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs>(kanaboardModel_KeyPressed);
            dictKanaInfo = new DictionaryKanaInfo();
        }

        void kanaboardModel_KeyPressed(object sender, Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs e)
        {
            if (kanaboardModel.KanaType == KanaType.Hiragana)
            {
                txtInput.FontFamily = DictionaryKanaInfo.HiraganaFont;
                txtInput.Text += dictKanaInfo[e.KanaKey].FontCode;
            }
            else
            {
                txtInput.FontFamily = DictionaryKanaInfo.KatakanaFont;
                txtInput.Text += dictKanaInfo[e.KanaKey].FontCode;
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            kanaboardModel.KanaType = KanaType.Hiragana;
        }

    }
}
