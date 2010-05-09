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

using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model
{
    public abstract class KanaboardBase : IKanaboardModel
    {
        public event EventHandler<KanaboardKeyPressedEventArgs> KeyPressed;
        public event EventHandler<KanaboardKanaTypeChangedEventArgs> KanaTypeChanged;

        public KanaboardBase(KanaType type)
        {
            this.kanaType = type;
        }

        private KanaType kanaType;
        public KanaType KanaType
        {
            get { return kanaType; }
            set
            {
                kanaType = value;
                if (this.KanaTypeChanged != null)
                {
                    KanaTypeChanged(this, new KanaboardKanaTypeChangedEventArgs(this.KanaType));
                }
            }
        }

        public void PressKey(KanaKey key)
        {
            if (this.KeyPressed != null)
            {
                KeyPressed(this, new KanaboardKeyPressedEventArgs(key));
            }
        }
    }
}
