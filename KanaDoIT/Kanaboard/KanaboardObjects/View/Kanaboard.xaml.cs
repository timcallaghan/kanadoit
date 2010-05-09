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

using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View
{
    public partial class Kanaboard : UserControl, IKanaboardView
    {
        private FontFamily fontFamily;
        private DictionaryKanaInfo dictKanaInfo;

        public Kanaboard()
        {
            InitializeComponent();

            dictKanaInfo = new DictionaryKanaInfo();

            UpdateTextAndFontFamily();
        }

        public void KanaTypeChanged(KanaType type)
        {
            switch (type)
            {
                case KanaType.Hiragana:
                    fontFamily = DictionaryKanaInfo.HiraganaFont;
                    break;
                case KanaType.Katakana:
                    fontFamily = DictionaryKanaInfo.KatakanaFont;
                    break;
                default:
                    fontFamily = null;
                    break;
            }

            UpdateTextAndFontFamily();
        }

        public event EventHandler<KanaboardKeyPressedEventArgs> KeyPressed;

        private void UpdateTextAndFontFamily()
        {
            if (fontFamily != null)
            {
                foreach (UIElement UIElement in LayoutRoot.Children)
                {
                    if (UIElement is Button)
                    {
                        Button btn = UIElement as Button;
                        btn.FontFamily = fontFamily;
                        btn.FontSize = 25;

                        btn.Content = dictKanaInfo[(KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true)].FontCode;
                    }
                }
            }
        }

        private void btnKey_Click(object sender, RoutedEventArgs e)
        {
            if (this.KeyPressed != null)
            {
                Button btn = sender as Button;
                this.KeyPressed
                    (
                        this,
                        new KanaboardKeyPressedEventArgs((KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true))
                    );
            }
        }
    }
}
