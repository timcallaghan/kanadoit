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

namespace Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View
{
    public interface IKanaboardView
    {
        void KanaTypeChanged(KanaType type);
        event EventHandler<KanaboardKeyPressedEventArgs> KeyPressed;
    }
}
