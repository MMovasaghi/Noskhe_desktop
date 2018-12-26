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
using noskhe_drugstore_app.Noskhes.Dones.ViewModels;
using noskhe_drugstore_app.Noskhes.Dones.Models;
using noskhe_drugstore_app.Models;
using System.Collections.ObjectModel;

namespace noskhe_drugstore_app.Noskhes.Dones
{
    /// <summary>
    /// Interaction logic for SellDetailUC.xaml
    /// </summary>
    public partial class DonesDetailUC : UserControl
    {
        SickMV sickMV = new SickMV();

        public DonesDetailUC()
        {
            InitializeComponent();
            DataContext = sickMV;
        }

        private void ReloadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SickPerson sp = new SickPerson
            {
                FirstName = "علی",
                LastName = "رضایی",
                Phone = "0912218934",
                //BirthDate = "1/1/1 - 12:00AM"
            };

            sickMV.sickDetailModel = new ObservableCollection<SickDetailModel>
            {
                new SickDetailModel{sickPerson = sp},
                new SickDetailModel{sickPerson = sp},
            };

            DonesDetail_DataGrid.ItemsSource = sickMV.sickDetailModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DonesDetail_DataGrid.ItemsSource = sickMV.sickDetailModel;
        }
    }
}
