using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using noskhe_drugstore_app.Noskhes.Doing.Models;
using noskhe_drugstore_app.Noskhes.Doing.ViewModels;
using System.Diagnostics;

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for NoskheImageDetails.xaml
    /// </summary>
    public partial class NoskheImageDetails : UserControl 
    {
        public string URL;
        public DetailsChartNoskheVM detailsChart = new DetailsChartNoskheVM();        

        public NoskheImageDetails()
        {
            InitializeComponent();
            DataContext = detailsChart;
            DrugDetailChart.ItemsSource = detailsChart.Details;
        }
        
        private void AcceptChange_Click(object sender, RoutedEventArgs e)
        {
            CalculateAllMoney();
            int Error = 0;
            int DrugNumber = 0;
            foreach (var item in detailsChart.Details)
            {
                if (item.AllMoney == 0 || item.Name == null)
                {
                    Error++;
                }
                else
                    DrugNumber += item.Number;
            }
            if (Error == 0 && AllMoney.Text != "0")
            {
                
                string Result = string.Format("Money : {0} Toman\nDrug Number : {1} \nIf they are correct , Please press YES button.", AllMoney.Text, DrugNumber);
                MessageBoxResult mbox = MessageBox.Show(Result, "Accepting", MessageBoxButton.YesNo,MessageBoxImage.Information);
                if (mbox == MessageBoxResult.Yes)
                {
                    //call Repository
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).DrugDetailForm.Visibility = Visibility.Hidden;
                            (window as MainWindow).XDrugDetailForm.Children.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"There are Some feild empty or incorrect.", "Warning", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }       

        private void DrugDetailChart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CalculateAllMoney();
        }

        private void CalculateAllMoney()
        {
            detailsChart.allMoney = 0;
            foreach (var item in detailsChart.Details)
            {
                detailsChart.allMoney += item.AllMoney;
            }
            AllMoney.Text = detailsChart.allMoney.ToString();
        }

        private void ImageItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(URL);
        }
    }
    

}
