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
        private bool isSelectMode = false;

        public Kanaboard()
        {
            InitializeComponent();

            StackPanelSelectAllButtons.Visibility = System.Windows.Visibility.Collapsed;

            UpdateTextAndFontFamily();
        }

        public void KanaTypeChanged(KanaType type)
        {
            fontFamily = KanaFont.GetKanaFont(type);
            UpdateTextAndFontFamily();
        }

        public event EventHandler<KanaboardKeyPressedEventArgs> KeyPressed;
        public event EventHandler<EventArgs> SelectAll;
        public event EventHandler<EventArgs> UnselectAll;

        public bool IsSelectMode
        {
            get
            {
                return isSelectMode;
            }
            set
            {
                isSelectMode = value;
                if (isSelectMode)
                {
                    StackPanelSelectAllButtons.Visibility = System.Windows.Visibility.Visible;
                    A_SMALL.IsEnabled = false;
                    I_SMALL.IsEnabled = false;
                    U_SMALL.IsEnabled = false;
                    E_SMALL.IsEnabled = false;
                    O_SMALL.IsEnabled = false;
                    COMMA.IsEnabled = false;
                    FULLSTOP.IsEnabled = false;
                    DOUBLE.IsEnabled = false;
                    LONG.IsEnabled = false;
                }
                else
                {
                    StackPanelSelectAllButtons.Visibility = System.Windows.Visibility.Collapsed;
                    A_SMALL.IsEnabled = true;
                    I_SMALL.IsEnabled = true;
                    U_SMALL.IsEnabled = true;
                    E_SMALL.IsEnabled = true;
                    O_SMALL.IsEnabled = true;
                    COMMA.IsEnabled = true;
                    FULLSTOP.IsEnabled = true;
                    DOUBLE.IsEnabled = true;
                    LONG.IsEnabled = true;
                }
            }
        }

        public void InitialiseFromList(ListKanaKeys listKanaKeys)
        {
            foreach (UIElement UIElement in LayoutRoot.Children)
            {
                if (UIElement is Button)
                {
                    Button btn = UIElement as Button;
                    if (listKanaKeys.Contains((KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true)))
                    {
                        ToggleButtonBorderThickness(btn);
                    }
                }
            }
        }

        public void DisableItemsNotInList(ListKanaKeys listKanaKeys)
        {
            foreach (UIElement UIElement in LayoutRoot.Children)
            {
                if (UIElement is Button)
                {
                    Button btn = UIElement as Button;
                    if (!listKanaKeys.Contains((KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true)))
                    {
                        btn.IsEnabled = false;
                    }
                }
            }
        }

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

                        if (fontFamily == KanaFont.HiraganaFont || fontFamily == KanaFont.KatakanaFont)
                        {
                            btn.Content = DictionaryKanaInfo.Instance[(KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true)].FontCode;
                            btn.FontSize = 25;
                        }
                        else if (fontFamily == KanaFont.RomajiFont)
                        {
                            btn.Content = DictionaryKanaInfo.Instance[(KanaKey)Enum.Parse(typeof(KanaKey), btn.Name, true)].Romaji;
                            btn.FontSize = 15;
                        }
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

                if (isSelectMode)
                {
                    ToggleButtonBorderThickness(btn);
                }
            }
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            Thickness thick = new Thickness(4.0, 4.0, 4.0, 4.0);

            foreach (UIElement UIElement in LayoutRoot.Children)
            {
                if (UIElement is Button)
                {
                    Button btn = UIElement as Button;
                    if (btn.IsEnabled)
                    {
                        btn.BorderThickness = thick;
                    }

                }
            }

            if (this.SelectAll != null)
            {
                this.SelectAll
                    (
                        this,
                        new EventArgs()
                    );
            }
        }

        private void btnUnselectAll_Click(object sender, RoutedEventArgs e)
        {
            Thickness thick = new Thickness(1.0, 1.0, 1.0, 1.0);

            foreach (UIElement UIElement in LayoutRoot.Children)
            {
                if (UIElement is Button)
                {
                    Button btn = UIElement as Button;
                    btn.BorderThickness = thick;
                }
            }

            if (this.UnselectAll != null)
            {
                this.UnselectAll
                    (
                        this,
                        new EventArgs()
                    );
            }
        }

        private void ToggleButtonBorderThickness(Button btn)
        {
            Thickness thick = new Thickness(4.0, 4.0, 4.0, 4.0);
            if (btn.BorderThickness.Equals(thick))
            {
                btn.BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
            }
            else
            {
                btn.BorderThickness = thick;
            }
        }
    }
}
