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
using System.Windows.Navigation;

using Arbaureal.Clock.ClockObjects;
using Arbaureal.Clock.ClockObjects.ClockModel;
using Arbaureal.Clock.ClockObjects.ClockPresenter;


namespace Arbaureal.KanaDoIT.Views
{
    public partial class Time : Page
    {
        private IClockModel clockModel;

        public Time()
        {
            InitializeComponent();

            clockModel = Arbaureal.Clock.ClockObjects.ClockModel.Clock.Create();
            clockModel.ClockData = new ClockData().Update(DateTime.Now);
            ClockPresenter presenter = new ClockPresenter(this.AnalogClockControl, clockModel);

            presenter.Response += new Callback(this.AnalogClockControl.Update);

            clockModel.ClockData = new ClockData().Update(new TimeSpan(0,21,59,15,0));
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
