using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using noskhe_drugstore_app.Models;
using noskhe_drugstore_app.Controller;
using noskhe_drugstore_app.Models.CustomExceptions;

namespace noskhe_drugstore_app.Status
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class StatusUC : UserControl
    {
        public StatusUC()
        {
            InitializeComponent();         
        }
        private async void CheckButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            
            try
            {
                Repository repo = new Repository();
                Descriptive result = await repo.Get_Server_Status();

                
                if (result != null || result.Success == true)
                {
                    CheckTxt.Text = "Connected";
                    CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF498232"));
                    CheckTxt.Visibility = Visibility.Visible;
                    DetailTxt.Visibility = Visibility.Hidden;
                }
                else
                {
                    CheckTxt.Text = "Disconnect";
                    CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                    CheckTxt.Visibility = Visibility.Visible;
                    DetailTxt.Visibility = Visibility.Hidden;
                }
            }
            catch (DATABASE_FAILURE ex)
            {
                CheckTxt.Text = "DATABASE_FAILURE";
                CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                DetailTxt.Text = ex.Message;
                DetailTxt.Visibility = Visibility.Visible;
                CheckTxt.Visibility = Visibility.Visible;

            }
            catch (NOT_RESPONDING ex)
            {
                CheckTxt.Text = "NOT_RESPONDING";
                CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                DetailTxt.Text = ex.Message;
                CheckTxt.Visibility = Visibility.Visible;
                DetailTxt.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                CheckTxt.Text = "Disconnect";
                CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                DetailTxt.Text = ex.Message + "\nCheck your Internet connection and Try Again.";
                CheckTxt.Visibility = Visibility.Visible;
                DetailTxt.Visibility = Visibility.Visible;
            }
            this.Cursor = Cursors.Arrow;
        }
        private async void LoginSignalR(object sender, RoutedEventArgs e)
        {
            //Connecting to Signal-R
            this.Cursor = Cursors.Wait;
            try
            {
                await SignalR.ConnectingLogin(SendUser.Text);
            }
            catch (Exception ex)
            {
                CheckTxt.Text = "Disconnect";
                CheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                DetailTxt.Text = ex.Message + "\nCheck your Internet connection and Try Again.";
                CheckTxt.Visibility = Visibility.Visible;
                DetailTxt.Visibility = Visibility.Visible;
            }
            this.Cursor = Cursors.Arrow;
        }
        private async void SendMessageSignalR(object sender, RoutedEventArgs e)
        {
            //sendmessage
            NotificationFirstSR nf = new NotificationFirstSR()
            {
                Url = new List<string>() { "ali", "hasan" },
                ListWithOutNoskhe = new List<WithOutNoskheFist>() { new WithOutNoskheFist() { Number = 10, Nlist = "noskhe" } },
            };
            await SignalR.SendMessage("salam", reciveUser.Text);
        }
    }
}
