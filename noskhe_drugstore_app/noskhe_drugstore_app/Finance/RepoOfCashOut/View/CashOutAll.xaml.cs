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
using noskhe_drugstore_app.Finance.RepoOfCashOut.ViewModels;

namespace noskhe_drugstore_app.Finance.RepoOfCashOut.View
{
    /// <summary>
    /// Interaction logic for CashOutAll.xaml
    /// </summary>
    public partial class CashOutAll : UserControl
    {
        public CashOutVM cashOutVM = new CashOutVM();
        public CashOutAll()
        {
            InitializeComponent();
            DataContext = cashOutVM;
        }

        private void Reload_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CashOutitemUC item1 = new CashOutitemUC();
            CashOutitemUC item2 = new CashOutitemUC();
            XDataShow.Children.Add(item1);
            XDataShow.Children.Add(item2);

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(300, GridUnitType.Pixel);
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(300, GridUnitType.Pixel);

            XDataShow.RowDefinitions.Add(row1);
            XDataShow.RowDefinitions.Add(row2);

            Grid.SetRow(item1, 0);
            Grid.SetRow(item2, 1);

            CashOutitemUC item3 = new CashOutitemUC();
            CashOutitemUC item4 = new CashOutitemUC();
            XDataShow.Children.Add(item3);
            XDataShow.Children.Add(item4);

            RowDefinition row3 = new RowDefinition();
            row3.Height = new GridLength(300, GridUnitType.Pixel);
            RowDefinition row4 = new RowDefinition();
            row4.Height = new GridLength(300, GridUnitType.Pixel);

            XDataShow.RowDefinitions.Add(row3);
            XDataShow.RowDefinitions.Add(row4);

            Grid.SetRow(item3, 2);
            Grid.SetRow(item4, 3);

        }
    }
}
