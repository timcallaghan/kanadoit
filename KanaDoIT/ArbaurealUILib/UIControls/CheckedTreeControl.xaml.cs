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
using System.Collections.ObjectModel;
using Arbaureal.ArbaurealUILib.DataSources;

namespace Arbaureal.ArbaurealUILib.UIControls
{
    public partial class CheckedTreeControl : UserControl
    {
        public CheckedTreeControl()
        {
            InitializeComponent();

        }

        public TreeView CheckedTreeView
        {
            get
            {
                return TreeView;
            }
        }
    }
}
