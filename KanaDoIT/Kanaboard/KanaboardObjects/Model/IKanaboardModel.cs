﻿using System;
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
    public interface IKanaboardModel
    {
        event EventHandler<KanaboardKeyPressedEventArgs> KeyPressed;
        event EventHandler<KanaboardKanaTypeChangedEventArgs> KanaTypeChanged;

        KanaType KanaType { get; set; }

        void PressKey(KanaKey key);
    }
}
