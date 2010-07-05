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

using Arbaureal.KanaDoIT.Clock.ClockObjects;
using Arbaureal.KanaDoIT.Clock.ClockObjects.ClockModel;
using Arbaureal.KanaDoIT.Clock.ClockObjects.ClockPresenter;
using Arbaureal.KanaDoIT.BaseResources;


namespace Arbaureal.KanaDoIT.Views.Time
{
    public partial class Time : TimeBaseView
    {
        private IClockModel clockModel;

        public Time()
        {
            InitializeComponent();

            clockModel = Arbaureal.KanaDoIT.Clock.ClockObjects.ClockModel.Clock.Create();
            clockModel.ClockData = new ClockData().Update(DateTime.Now);
            ClockPresenter presenter = new ClockPresenter(this.AnalogClockControl, clockModel);

            presenter.Response += new Callback(this.AnalogClockControl.Update);

            clockModel.ClockData = new ClockData().Update(new TimeSpan(0,21,59,15,0));
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            KanaDictionary dict = KanaDictionary.Instance;

            foreach (KeyValuePair<int, Word> kvp in dict)
            {
                foreach (Run textRun in kvp.Value.GetWordKana(40.0))
                {
                    deets.Inlines.Add(textRun);
                }
                deets.Inlines.Add(Environment.NewLine);
                deets.Inlines.Add(kvp.Value.Romaji);
                deets.Inlines.Add(Environment.NewLine);
            }            
        }

        private void btnNewTime_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int hours = rand.Next(24);
            int minutes = rand.Next(12)*5;
            int seconds = minutes;

            clockModel.ClockData = new ClockData().Update(new TimeSpan(0, hours, minutes, seconds, 0));
        }

    }
}
