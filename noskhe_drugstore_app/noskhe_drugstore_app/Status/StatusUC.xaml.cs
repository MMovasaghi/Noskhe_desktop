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
                Descriptive result = await repo.Get_DB_Status();

                
                if (result != null || result.Success == true)
                {
                    DBCheckTxt.Text = "Connected";
                    DBCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF498232"));
                    DBCheckTxt.Visibility = Visibility.Visible;
                    DBDetailTxt.Visibility = Visibility.Hidden;
                }
                else
                {
                    DBCheckTxt.Text = "Disconnect";
                    DBCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                    DBCheckTxt.Visibility = Visibility.Visible;
                    DBDetailTxt.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                DBCheckTxt.Text = "Disconnect";
                DBCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                DBDetailTxt.Text = ex.Message + "\nCheck your Internet connection and Try Again.";
                DBCheckTxt.Visibility = Visibility.Visible;
                DBDetailTxt.Visibility = Visibility.Visible;
            }
            try
            {
                Repository repo = new Repository();
                Descriptive result = await repo.Get_Server_Status();


                if (result != null || result.Success == true)
                {
                    SERVERCheckTxt.Text = "Connected";
                    SERVERCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF498232"));
                    SERVERCheckTxt.Visibility = Visibility.Visible;
                    SERVERDetailTxt.Visibility = Visibility.Hidden;
                }
                else
                {
                    SERVERCheckTxt.Text = "Disconnect";
                    SERVERCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                    SERVERCheckTxt.Visibility = Visibility.Visible;
                    SERVERDetailTxt.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                SERVERCheckTxt.Text = "Disconnect";
                SERVERCheckTxt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF772412"));
                SERVERDetailTxt.Text = ex.Message + "\nCheck your Internet connection and Try Again.";
                SERVERCheckTxt.Visibility = Visibility.Visible;
                SERVERDetailTxt.Visibility = Visibility.Visible;
            }
            this.Cursor = Cursors.Arrow;
        }
    }
}
