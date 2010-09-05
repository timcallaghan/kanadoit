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

using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Presenter;
using Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.View;
using Arbaureal.KanaDoIT.BaseResources;

namespace Arbaureal.KanaDoIT.Views.Phrases
{
    public partial class PhraseSelection : PhrasesBaseView
    {
        private IKanaboardModel kanaboardModel;

        public PhraseSelection()
        {
            InitializeComponent();

            //kanaboardModel = Arbaureal.KanaDoIT.Kanaboard.KanaboardObjects.Model.Kanaboard.Create(KanaType.Phrases);
            //KanaboardPresenter presenter = new KanaboardPresenter(this.Kanaboard, kanaboardModel);
            //this.Kanaboard.IsSelectMode = true;
            //this.Kanaboard.SelectAll += new EventHandler<EventArgs>(Kanaboard_SelectAll);
            //this.Kanaboard.UnselectAll += new EventHandler<EventArgs>(Kanaboard_UnselectAll);
            //kanaboardModel.KeyPressed += new EventHandler<KanaDoIT.Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs>(kanaboardModel_KeyPressed);
        }

        void Kanaboard_SelectAll(object sender, EventArgs e)
        {
            //ListKanaKeys.Clear();
            //CheckListOfKanaKeys();
        }

        void Kanaboard_UnselectAll(object sender, EventArgs e)
        {
            //ListKanaKeys.Clear();
        }

        void kanaboardModel_KeyPressed(object sender, Kanaboard.KanaboardObjects.KanaboardKeyPressedEventArgs e)
        {
            //if (ListKanaKeys.Contains(e.KanaKey))
            //{
            //    ListKanaKeys.Remove(e.KanaKey);
            //}
            //else
            //{
            //    ListKanaKeys.Add(e.KanaKey);
            //}
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //kanaboardModel.KanaType = KanaType.Phrases;
            //this.Kanaboard.IsSelectMode = true;
            //this.Kanaboard.InitialiseFromList(ListKanaKeys);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //ListKanaKeys.Sort();

            base.OnNavigatedFrom(e);
        }
    }
}
