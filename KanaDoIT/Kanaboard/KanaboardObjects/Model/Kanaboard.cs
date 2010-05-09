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
    public class Kanaboard : KanaboardBase
    {
        public static IKanaboardModel Create(KanaType type)
        {
            return new Kanaboard(type);
        }

        private Kanaboard(KanaType type)
            : base(type)
        {
        }
    }
}
