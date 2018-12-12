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
using System.Windows.Threading;
using noskhe_drugstore_app.AcceptPH.ViewModels;
using noskhe_drugstore_app.Noskhes.Doing.View;
using noskhe_drugstore_app.Persons;
using noskhe_drugstore_app.Controller;

namespace noskhe_drugstore_app.AcceptPH
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class AcceptUC : UserControl
    {
        TimerACVM timerVM = new TimerACVM();
        public AcceptUC()
        {
            InitializeComponent();
            DataContext = timerVM;            
            //button click
            //TimerVM.StartTimer();
            //TimerVM.timerModel.sec = 60;
        } 
        private void RefuseButton_Click(object sender, RoutedEventArgs e)
        {           

            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که می خوهید نسخه را نبپذیرید ؟", "Refusing", MessageBoxButton.YesNo);
            if (mbox == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).AcceptForm.Visibility = Visibility.Hidden;
                        }
                    }

                    //Stop the timer of Acceptance page
                    if (TimerACVM.dt != null)
                    {
                        TimerACVM.dt.Stop();
                    }
                    TimerACVM.timerModel.TimerAlert = Brushes.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }                                 
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که می خوهید نسخه را بپذیرید ؟", "Accepting", MessageBoxButton.YesNo);
            if (mbox == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).AcceptForm.Visibility = Visibility.Hidden;
                        }
                    }

                    //Stop the timer of Acceptance page
                    if (TimerACVM.dt != null)
                    {
                        TimerACVM.dt.Stop();
                    }
                    TimerACVM.timerModel.TimerAlert = Brushes.White;

                    SickPerson sp = new SickPerson
                    {
                        FirstName = "رضا",
                        LastName = "احمدی",
                        Phone = "0912218934",
                        BirthDate = "1/1/1 - 12:00AM"
                    };
                    DoingDetailUC doingObj = new DoingDetailUC();
                    doingObj.doingSicks.getparam(sp);
                    doingObj.doingSicks.StartTimer();
                    doingObj.Height = 300;

                    doingObj.d = new DoingDetailofallUC();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).GridsShow(ref (window as MainWindow).NoskhesGrid, "نسخه ها", true, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);
                            (window as MainWindow).nostest.DonesGrid.Visibility = Visibility.Hidden;
                            (window as MainWindow).nostest.DoingGrid.Visibility = Visibility.Visible;
                            (window as MainWindow).nostest.xpanel.Children.Add(doingObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }            

        }
    }
}
