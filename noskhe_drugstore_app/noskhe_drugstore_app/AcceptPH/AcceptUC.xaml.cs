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
using noskhe_drugstore_app.Controller;
using noskhe_drugstore_app.Models;
using Notifications.Wpf;
using noskhe_drugstore_app.Models.CustomExceptions;

namespace noskhe_drugstore_app.AcceptPH
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class AcceptUC : UserControl
    {
        private NotificationManager notificationManager;

        TimerACVM timerVM = new TimerACVM();
        public SickPerson sickPersonObj { get; set; }
        public noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop NoskheForFirstNotificationOnDesktop { get; set; }
        public AcceptUC()
        {
            InitializeComponent();
            DataContext = timerVM;           
        }
        private void RefuseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که می خوهید نسخه را نبپذیرید ؟", "Refusing", MessageBoxButton.YesNo);
            if (mbox == MessageBoxResult.Yes)
            {
                try
                {
                    Acceptace(NoskheForFirstNotificationOnDesktop.Notation.ShoppingCartId, false, 0);
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
                    Acceptace(NoskheForFirstNotificationOnDesktop.Notation.ShoppingCartId, true, 0);
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

                    DoingDetailUC doingObj = new DoingDetailUC();
                    //should send a request to server to get all data
                    doingObj.ShowOnScreen(NoskheForFirstNotificationOnDesktop);
                    doingObj.doingSicks.InitializeTimer();
                    doingObj.doingSicks.StartTimer();                    
                    doingObj.Height = 300;

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).GridsShow(ref (window as MainWindow).NoskhesGrid, "نسخه ها", true, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);
                            (window as MainWindow).NoskheFirstPage.DoingGrid.Visibility = Visibility.Visible;
                            (window as MainWindow).NoskheFirstPage.xpanel.Children.Add(doingObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }            

        }
        public void GetObjectOfNoskhe(noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop obj)
        {
            NoskheForFirstNotificationOnDesktop = obj;
            NoskheForFirstNotificationOnDesktop.SumAllPrice = 0;
            NoskheForFirstNotificationOnDesktop.NumberOfNoskhe = 0;
            NoskheForFirstNotificationOnDesktop.NumberOfWithOutNoskhe = 0;
            try
            {
                foreach (var item in NoskheForFirstNotificationOnDesktop.Picture_Urls)
                {
                    ShowOn(item);
                    NoskheForFirstNotificationOnDesktop.NumberOfNoskhe++;
                }
                int X = 0;
                int number = 0;
                foreach (var item in NoskheForFirstNotificationOnDesktop.Cosmetics)
                {
                    X++;
                    number += item.Number;
                    ShowWithoutNoskhe(X, item.Name, item.Number);
                    NoskheForFirstNotificationOnDesktop.SumAllPrice += (item.Price * item.Number);
                }
                foreach (var item in NoskheForFirstNotificationOnDesktop.Medicines)
                {
                    X++;
                    number += item.Number;
                    ShowWithoutNoskhe(X, item.Name, item.Number);
                    NoskheForFirstNotificationOnDesktop.SumAllPrice += (item.Price * item.Number);
                }
                NoskheForFirstNotificationOnDesktop.NumberOfWithOutNoskhe = X;
            }
            catch (PICTURE_FAILURE)
            {
                MessageBox.Show("PICTURE_FAILURE", "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new PICTURE_FAILURE();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Sending Out notification on the screen -----------------------------------------------------
            try
            {                
                notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Noskhe (Pharmacy App.)",
                    Message = "With Noskhe : " + NoskheForFirstNotificationOnDesktop.NumberOfNoskhe.ToString() 
                            + "\nWith Out Noskhe : " + NoskheForFirstNotificationOnDesktop.NumberOfWithOutNoskhe.ToString(),
                    Type = NotificationType.Success

                });                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //--------------------------------------------------------------------------------------------
        }
        public void ShowOn(string url)
        {
            try
            {  

                //Show Image On the screen--------------------------------------------------------------------
                var image = new Image();
                var fullFilePath = url;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;

                //With-Noskhe-Picture 
                ShowImagePanel showImagePanel = new ShowImagePanel();
                showImagePanel.XShowImage.Children.Add(image);
                showImagePanel.ImageUrl = url;

                XWithNoskhePanel.Children.Add(showImagePanel);

                
            }
            catch (Exception)
            {
                throw new PICTURE_FAILURE();
            }
        }
        public void ShowWithoutNoskhe(int Row , string Name , int Number)
        {
            try
            {
                //With-Out-Noskhe-
                WithoutNoskhePart withoutNoskhePart = new WithoutNoskhePart();
                withoutNoskhePart.XpanelRow.Text = Row.ToString();
                withoutNoskhePart.XpanelName.Text = Name;
                withoutNoskhePart.XpanelNumber.Text = Number.ToString();

                XWithOutNpanel.Children.Add(withoutNoskhePart);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Acceptace(int shoppingCartId, bool accepted, PharmacyCancellationReason reason)
        {
            try
            {
                Repository repository = new Repository();
                await repository.AcceptanceOfNoskhe(shoppingCartId, accepted, reason);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EXCEPTION", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
