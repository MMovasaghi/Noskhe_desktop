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
using System.Diagnostics;
using System.Windows.Threading;
using noskhe_drugstore_app.Noskhes.Doing.ViewModels;
using noskhe_drugstore_app.Persons;

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for FinanceDetailUC.xaml
    /// </summary>
    public partial class DoingDetailUC : UserControl
    {

        public DoingSicksMV doingSicks = new DoingSicksMV();
        public DoingDetailUC()
        {
            InitializeComponent();

            DataContext = doingSicks;

            //TimerVM.timerModel.Sec = 0;
            //TimerVM.timerModel.Min = 0;
            //TimerVM.StartTimer();

            DateTimetxt.Text = DateTime.Now.ToString();            
        }

        private void MainGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).XDingdetail.Children.Clear();
                }
            }
            
            SickPerson sp = new SickPerson
            {
                FirstName = SickFirstName.Text,
                LastName = SickLastName.Text,
                Phone = "0912218934",
                BirthDate = "1/1/1 - 12:00AM"
            };
            DoingDetailofallUC d = new DoingDetailofallUC();
            d.doingSicks.getparam(sp);


            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).XDingdetail.Children.Add(d);
                    //(window as MainWindow).XDingdetail.Children.Clear();
                    (window as MainWindow).GridsShow(ref (window as MainWindow).DoingDetailGrid, "جزئیات نسخه", true, MaterialDesignThemes.Wpf.PackIconKind.ContentDuplicate);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که نسخه پیچیده شده است ؟", "Warrning", MessageBoxButton.YesNo);
        }
    }
}
