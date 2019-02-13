using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace noskhe_drugstore_app.Noskhes.Dones
{
    /// <summary>
    /// Interaction logic for SellDetailUC.xaml
    /// </summary>
    public partial class DonesDetailUC : UserControl
    {
        private ViewModel viewModel = new ViewModel();
        public DonesDetailUC()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ReloadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowOnGrid();
        }
        public void ShowOnGrid()
        {
            viewModel.GetData();
        }
    }
}
