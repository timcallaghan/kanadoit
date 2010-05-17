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
using System.IO;
using System.Windows.Markup;

using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Nouns
{
    public partial class Nouns : NounsBaseView
    {
        private BaseResources.DictionaryNouns dictNouns;
        private Random random;
        private int nCurrentKey;

        private List<BaseResources.NounInfo> listChoices;

        public Nouns()
        {
            InitializeComponent();

            listChoices = new List<BaseResources.NounInfo>();
            random = new Random();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dictNouns = new BaseResources.DictionaryNouns();

            listChoices = dictNouns.GetRandonNounList();

            nCurrentKey = random.Next(4);

            var streamResourceInfo = Application.GetResourceStream
                (
                    listChoices[nCurrentKey].ImageFilePath
                );

            string xaml = null;

            using (var resourceStream = streamResourceInfo.Stream)
            {
                using (var streamReader = new StreamReader(resourceStream))
                {
                    xaml = streamReader.ReadToEnd();
                }
            }

            Canvas canvas = XamlReader.Load(xaml) as Canvas;

            NounImage.Content = canvas;

            btnChoiceA.Content = listChoices[0].GetNounKana();
            btnChoiceB.Content = listChoices[1].GetNounKana();
            btnChoiceC.Content = listChoices[2].GetNounKana();
            btnChoiceD.Content = listChoices[3].GetNounKana();
        }

        private void btnChoice_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = sender as Button;

            int nSelectedIndex = -1;
            if (btnSender.Name == "btnChoiceA")
            {
                nSelectedIndex = 0;
            }
            else if (btnSender.Name == "btnChoiceB")
            {
                nSelectedIndex = 1;
            }
            else if (btnSender.Name == "btnChoiceC")
            {
                nSelectedIndex = 2;
            }
            else if (btnSender.Name == "btnChoiceD")
            {
                nSelectedIndex = 3;
            }

            if (nSelectedIndex != nCurrentKey)
            {
                Result.Text = "WRONG!";
                btnSender.IsEnabled = false;
            }
            else
            {
                Result.Text = "CORRECT!";
                btnChoiceA.IsEnabled = true;
                btnChoiceB.IsEnabled = true;
                btnChoiceC.IsEnabled = true;
                btnChoiceD.IsEnabled = true;

                listChoices = dictNouns.GetRandonNounList();

                nCurrentKey = random.Next(4);

                var streamResourceInfo = Application.GetResourceStream
                    (
                        listChoices[nCurrentKey].ImageFilePath
                    );

                string xaml = null;

                using (var resourceStream = streamResourceInfo.Stream)
                {
                    using (var streamReader = new StreamReader(resourceStream))
                    {
                        xaml = streamReader.ReadToEnd();
                    }
                }

                Canvas canvas = XamlReader.Load(xaml) as Canvas;

                NounImage.Content = canvas;

                btnChoiceA.Content = listChoices[0].GetNounKana();
                btnChoiceB.Content = listChoices[1].GetNounKana();
                btnChoiceC.Content = listChoices[2].GetNounKana();
                btnChoiceD.Content = listChoices[3].GetNounKana();
            }
        }

    }
}
