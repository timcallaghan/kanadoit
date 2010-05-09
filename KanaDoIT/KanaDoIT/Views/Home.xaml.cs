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

using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Presenter;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View;

namespace Arbaureal.KanaDoIT
{
    public partial class Home : Page
    {
        private BaseResources.ChimeGenerator chimeGenerator;
        private IKanaboardModel kanaboardModel;

        public Home()
        {
            InitializeComponent();

            kanaboardModel = Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model.Kanaboard.Create(KanaType.Hiragana);
            KanaboardPresenter presenter = new KanaboardPresenter(this.Kanaboard, kanaboardModel);
            kanaboardModel.KeyPressed += new EventHandler<KanaDoIT.Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs>(kanaboardModel_KeyPressed);
        }

        void kanaboardModel_KeyPressed(object sender, Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs e)
        {
            if (kanaboardModel.KanaType == KanaType.Hiragana)
            {
                kanaboardModel.KanaType = KanaType.Katakana;
            }
            else
            {
                kanaboardModel.KanaType = KanaType.Hiragana;
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            chimeGenerator = new BaseResources.ChimeGenerator(LayoutRoot);
            kanaboardModel.KanaType = KanaType.Katakana;
        }

        private void Link_MouseEnter(object sender, MouseEventArgs e)
        {
            chimeGenerator.PlayRandomChime();
        }
    }
}