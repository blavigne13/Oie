﻿using Oie.ViewModels;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oie.Views
{
    /// <summary>
    /// Interaction logic for UseCase16View.xaml
    /// </summary>
    public partial class UseCase16View : UserControl
    {
        public UseCase16View()
        {
            this.DataContext = new UseCase16ViewModel();
            this.InitializeComponent();
        }
        
        private void ascendingRadio_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
