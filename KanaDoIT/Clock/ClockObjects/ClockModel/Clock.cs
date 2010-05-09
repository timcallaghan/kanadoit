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

namespace Arbaureal.KanaDoIT.Clock.ClockObjects.ClockModel
{
    public class Clock : ClockBase
    {
        public static IClockModel Create()
        {
            return new Clock();
        }

        public override IClockModel Start()
        {
            if (IsRunning)
                return this;

            timer.Start();
            isRunning = true;

            return this;
        }

        public override IClockModel Stop()
        {
            timer.Stop();
            isRunning = false;

            return this;
        }

        public override IClockModel Continue()
        {
            return this.Start();
        }

        protected override void UpdateClockData(DateTime dateTime)
        {
            this.ClockData.Update(dateTime);
        }
    }
}
