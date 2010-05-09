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

namespace Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects
{
    public class KanaboardKeyPressedEventArgs : EventArgs
    {
        public KanaboardKeyPressedEventArgs(KanaKey key)
        {
            this.KanaKey = key;
        }

        public KanaKey KanaKey
        {
            get;
            protected set;
        }
    }

    public class KanaboardKanaTypeChangedEventArgs : EventArgs
    {
        public KanaboardKanaTypeChangedEventArgs(KanaType type)
        {
            this.KanaType = type;
        }

        public KanaType KanaType
        {
            get;
            protected set;
        }
    }
}
