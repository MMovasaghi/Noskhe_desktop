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
        string user;
        string pass;
        public LoginUC()
        {
            InitializeComponent();

            AppData appData = new AppData();
            if (!appData.IsNOtExist())
            {
                string[] res = appData.ReadData();
                Username_box.Text = res[0];
                Password_box.Password = res[1];
            }
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
            else if (button.Name == "FSGoBack")
            {
                FSGrid.Visibility = Visibility.Hidden;
                LoginGrid.Visibility = Visibility.Visible;
                FSText.Text = "FS text";
            }
        }
        private async void CheckLogin()
        {
            user = Username_box.Text;
            pass = Password_box.Password;
            try
            {               

                Repository repo = new Repository();
                string[] Login = { user, pass };

                bool result = await repo.Check_Login(Login);
                if (result)
                {
                    //Connecting to Signal-R
                    //await SignalR.ConnectingLogin("ali"); 

                    //save on the file
                    if (CheckBox_save.IsChecked == true)
                    {
                        save();
                    }

                    //var p = await repo.Get_Pharmacy_Info();

                    Application.Current.Dispatcher.Invoke(new Action(
                        delegate {

                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window.GetType() == typeof(MainWindow))
                                {
                                    //(window as MainWindow).PharmacyName_MainPage.Text = p.Name;
                                    (window as MainWindow).LoginGrid.Visibility = Visibility.Hidden;
                                }
                            }
                        }
                    ));

                }
                else
                {
                    WarningText.Text = "Password or Username is incorrect !";
                    WarningGrid.Visibility = Visibility.Visible;
                    LoginGrid.Visibility = Visibility.Hidden;

                }                
                
            }
            catch (Exception ex)
            {
                MessageBoxResult mbox1 = MessageBox.Show("Your Password or Username is incorrect !\n" + ex.Message, "Warrning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }
        private bool save()
        {
            AppData appData = new AppData();
            if (appData.IsNOtExist())
            {
                //save data in the appdata
                return appData.SaveData(Username_box.Text , Password_box.Password);
            }
            return false;
        }

        private void FS_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FSText.Text = "Please Call To Noskhe Tec Team.\n\nPhone : 09122184357";
            FSGrid.Visibility = Visibility.Visible;
            LoginGrid.Visibility = Visibility.Hidden;
        }
    }
}
