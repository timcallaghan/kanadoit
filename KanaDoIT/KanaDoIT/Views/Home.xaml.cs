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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT
{
    public partial class Home : Page
    {
        private BaseResources.ChimeGenerator chimeGenerator;

        public Home()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            chimeGenerator = new BaseResources.ChimeGenerator(LayoutRoot); 
        }

        private void Link_MouseEnter(object sender, MouseEventArgs e)
        {
            //HyperlinkButton btnSender = sender as HyperlinkButton;
            chimeGenerator.PlayRandomChime();
        }
    }
}