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

namespace Arbaureal.Clock.ClockObjects
{
    public class ClockDataEventArgs : EventArgs
    {
        public ClockDataEventArgs(ClockData clockData)
        {
            this.ClockData = clockData;
        }

        public ClockData ClockData
        {
            get;
            protected set;
        }
    }
}
