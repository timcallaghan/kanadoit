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

namespace Arbaureal.KanaDoIT.Views
{
    public partial class Installation : Page
    {
        public Installation()
        {
            InitializeComponent();
            if (App.Current.IsRunningOutOfBrowser)
            {
                this.Title = "Uninstall";
                this.HeaderText.Text = "Uninstallation";
                this.InstallActionText1.Text = "You can remove KanaDoIT from your computer if you no longer wish to use it.";
                this.InstallActionText2.Text = "To remove KanaDoIT, right click on this text and select \"Remove this application...\".";
                this.btnInstallAction.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnInstallAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Install();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("KanaDoIT is already installed on this computer.");
            }
        }

    }
}
