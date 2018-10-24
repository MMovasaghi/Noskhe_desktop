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
using noskhe_drugstore_app.Controller;

namespace noskhe_drugstore_app.Login
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        public LoginUC()
        {
            InitializeComponent();
        }

        private void loginbut_Click(object sender, RoutedEventArgs e)
        {
             CheckLogin();
        }

        private void Password_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckLogin();
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "WarningGoBack")
            {
                WarningGrid.Visibility = Visibility.Hidden;
                LoginGrid.Visibility = Visibility.Visible;
                WarningText.Text = "Warning text";
            }
            else if (button.Name == "ErrorGoBack")
            {
                ErrorGrid.Visibility = Visibility.Hidden;
                LoginGrid.Visibility = Visibility.Visible;
                ErrorText.Text = "Error text";
            }
        }
        private async void CheckLogin()
        {
            try
            {
                Repository repo = new Repository();
                string[] Login = { Username_box.Text, Password_box.Password };
                bool result = await repo.Check_Login(Login);
                if (result)
                {
                    //Connecting to Signal-R
                    //await SignalR.ConnectingLogin("ali");

                    CurrentUser currentUser = new CurrentUser();
                    currentUser.SetDATAasync(Username_box.Text);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).LoginGrid.Visibility = Visibility.Hidden;
                        }
                    }

                    var myWindow = Window.GetWindow(this);
                    myWindow.Close();

                }
                else
                {
                    Username_box.Text = "";
                    Password_box.Password = "";
                    WarningText.Text = "Password or Username is incorrect !";
                    WarningGrid.Visibility = Visibility.Visible;
                    LoginGrid.Visibility = Visibility.Hidden;

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult mbox1 = MessageBox.Show("Your Password or Username is incorrect !" + ex.Message, "Warrning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }
    }
}
