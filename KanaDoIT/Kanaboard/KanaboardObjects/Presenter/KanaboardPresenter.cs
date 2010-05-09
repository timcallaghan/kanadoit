using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View;

namespace Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Presenter
{
    public class KanaboardPresenter
    {
        public IKanaboardView KanaboardView
        {
            get;
            set;
        }

        public IKanaboardModel KanaboardModel
        {
            get;
            set;
        }

        public KanaboardPresenter(IKanaboardView kanaboardView, IKanaboardModel kanaboardModel)
        {
            this.KanaboardView = kanaboardView;
            this.KanaboardModel = kanaboardModel;

            this.KanaboardModel.KanaTypeChanged += new EventHandler<KanaboardKanaTypeChangedEventArgs>(KanaboardModel_KanaTypeChanged);
            this.KanaboardView.KeyPressed += new EventHandler<KanaboardKeyPressedEventArgs>(KanaboardView_KeyPressed);
        }

        void KanaboardModel_KanaTypeChanged(object sender, KanaboardKanaTypeChangedEventArgs e)
        {
            this.KanaboardView.KanaTypeChanged(e.KanaType);
        }

        private void KanaboardView_KeyPressed(object sender, KanaboardKeyPressedEventArgs e)
        {
            this.KanaboardModel.PressKey(e.KanaKey);
        }
    }
}
