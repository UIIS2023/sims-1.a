﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.OwnerViews
{
    /// <summary>
    /// Interaction logic for DemoIsOnView.xaml
    /// </summary>
    public partial class DemoIsOnView : Window
    {
        public DemoIsOnView()
        {
            InitializeComponent();
            this.Owner = Application.Current.Windows.OfType<OwnerMainWindowView>().FirstOrDefault();
        }
    }
}
