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

namespace Arbaureal.KanaDoIT
{
    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.Application_Startup;
            this.UnhandledException += this.Application_UnhandledException;
            this.CheckAndDownloadUpdateCompleted += new CheckAndDownloadUpdateCompletedEventHandler(App_CheckAndDownloadUpdateCompleted);
            InitializeComponent();
        }

        void App_CheckAndDownloadUpdateCompleted(object sender, CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                MessageBox.Show("An update for KanaDoIT has been downloaded. " +
                    "Please restart KanaDoIT to run the new version.");
            }
            else if (e.Error != null && e.Error is PlatformNotSupportedException)
            {
                MessageBox.Show("An update for KanaDoIT is available, " +
                    "but it requires a newer version of Silverlight. " +
                    "Please close KanaDoIT and then download and install the latest version of Silverlight.");
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.CheckAndDownloadUpdateAsync();
            this.RootVisual = new MainPage();            

            if (App.Current.IsRunningOutOfBrowser)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // a ChildWindow control.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                ChildWindow errorWin = new ErrorWindow(e.ExceptionObject);
                errorWin.Show();
            }
        }
    }
}