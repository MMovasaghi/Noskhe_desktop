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
using System.Windows.Navigation;
using System.Windows.Shapes;
using noskhe_drugstore_app.Noskhes.Doing;
using noskhe_drugstore_app.Models;
using noskhe_drugstore_app.Noskhes.Dones;

namespace noskhe_drugstore_app.Noskhes
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class NoskhesUC : UserControl
    {
        public DonesUC donesUC { get; set; }
        public NoskhesUC()
        {
            InitializeComponent();
        }

        private void DonesItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            donesUC = new DonesUC();
            donesUC.ShowDetail();
            DonesGrid.Children.Add(donesUC);

            DonesGrid.Visibility = Visibility.Visible;
            DoingGrid.Visibility = Visibility.Hidden;
        }

        private void DoingItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DonesGrid.Visibility = Visibility.Hidden;
            DoingGrid.Visibility = Visibility.Visible;
        }
    }
}
