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
using LiveCharts;
using LiveCharts.Wpf;
using noskhe_drugstore_app.Finance.RepoOfCashOut.View;

namespace noskhe_drugstore_app.Finance
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class FinanceUC : UserControl
    {

        public FinanceUC()
        {
            InitializeComponent();
        }

        private void FinanceRe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FinanceRepo.Visibility = Visibility.Visible;
            CachOutRepo.Visibility = Visibility.Hidden;
            ShowOn();
        }
        public async void ShowOn()
        {
            Controller.Repository repo = new Controller.Repository();
            Models.Minimals.Output.Pharmacy pharmacy = await repo.Get_Pharmacy_Info();
            Credittext.Text = pharmacy.Credit.ToString();
        }
        private async void CachOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FinanceRepo.Visibility = Visibility.Hidden;
            CachOutRepo.Visibility = Visibility.Visible;

            try
            {
                Controller.Repository repo = new Controller.Repository();
                List<Models.Minimals.Output.Settle> allSattle = await repo.Get_AllSettle();
                CashOutAll cashOutAll = new CashOutAll();

                int i = 0;               

                foreach (var item in allSattle)
                {
                    CashOutitemUC item1 = new CashOutitemUC();
                    item1.CreditAll.Text = item.Credit.ToString();
                    item1.PersentOfCashOut.Text = ((item.Credit * 3) / 100).ToString();
                    item1.EndCreditCashOut.Text = (item.Credit - (item.Credit * 3) / 100).ToString();
                    item1.DateOfCashOut.SelectedDate = item.Date;
                    item1.NumberOfCashOut.Text = item.NumberOfOrders.ToString();
                    item1.SerialOfCashOut.Text = item.USI.ToString();

                    cashOutAll.XDataShow.Children.Add(item1);
                    RowDefinition row1 = new RowDefinition();
                    row1.Height = new GridLength(300, GridUnitType.Pixel);
                    cashOutAll.XDataShow.RowDefinitions.Add(row1);
                    Grid.SetRow(item1, i);
                    i++;
                }
                CachOutRepo.Children.Add(cashOutAll);
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
