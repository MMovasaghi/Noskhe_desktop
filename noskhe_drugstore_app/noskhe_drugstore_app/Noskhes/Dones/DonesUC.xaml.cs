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

namespace noskhe_drugstore_app.Noskhes.Dones
{
    /// <summary>
    /// Interaction logic for DonesUC.xaml
    /// </summary>
    public partial class DonesUC : UserControl
    {
        public DonesUC()
        {
            InitializeComponent();
        }
        public void ShowDetail()
        {
            DonesDetailUC donesDetailUC = new DonesDetailUC();
            donesDetailUC.ShowOnGrid();
            XPanel.Children.Add(donesDetailUC);
        }
    }
}
