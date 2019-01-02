using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using noskhe_drugstore_app.Noskhes.Doing.ViewModels;

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for FinanceDetailUC.xaml
    /// </summary>
    public partial class DoingDetailUC : UserControl
    {
        public DoingDetailofallUC doingDetailofallUC { get; set; }

        public DoingSicksMV doingSicks = new DoingSicksMV();
        public noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop NoskheForFirstNotificationOnDesktop { get; set; }
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

            doingDetailofallUC.doingSicks.InitializeTimer();


            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).XDingdetail.Children.Add(doingDetailofallUC);
                    //(window as MainWindow).XDingdetail.Children.Clear();
                    (window as MainWindow).GridsShow(ref (window as MainWindow).DoingDetailGrid, "جزئیات نسخه", true, MaterialDesignThemes.Wpf.PackIconKind.ContentDuplicate);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که نسخه پیچیده شده است ؟", "Warrning", MessageBoxButton.YesNo);
            if(mbox == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).nostest.xpanel.Children.Remove(this);
                        }
                    }
                }
                catch (Exception)
                {

                }
                
            }
        }
        
        public void ShowOnScreen(noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop NoskheNotificationArg)
        {
            
            this.SickLastName.Text = NoskheNotificationArg.Customer.LastName;
            this.SickFirstName.Text = NoskheNotificationArg.Customer.FirstName;
            this.Moneytxt.Text = NoskheNotificationArg.SumAllPrice.ToString();
            this.WithOutNoskhe.Text = NoskheNotificationArg.NumberOfWithOutNoskhe.ToString();
            this.WithNoskhe.Text = NoskheNotificationArg.NumberOfNoskhe.ToString();
            //object of Details
            doingDetailofallUC = new DoingDetailofallUC();
            doingDetailofallUC.ShowOnScreen(NoskheNotificationArg, ref this.Moneytxt);
        }

       
    }
}
