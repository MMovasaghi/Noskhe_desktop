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
using noskhe_drugstore_app.AcceptPH.ViewModels;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using noskhe_drugstore_app.Profile;
using noskhe_drugstore_app.AcceptPH;
using noskhe_drugstore_app.Controller;
using noskhe_drugstore_app.Models;
using noskhe_drugstore_app.Models.Minimals.Output;
using MaterialDesignThemes.Wpf;

namespace noskhe_drugstore_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Finance.FinanceUC financeUC { get; set; }
        public Star.StarUC starUC { get; set; }
        public Status.StatusUC statusUC { get; set; }
        public Login.LoginUC loginUC { get; set; }
        public ProfileUC profileuc { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Minimizedbut_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Maximizesbut_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                WindowMaxIco.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                WindowMaxIco.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }
        private void Drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ButtonPopuplogout_Click(object sender, RoutedEventArgs e)
        {
            Repository.LoginSignalR = true;
            Logout();

            GridsShow(ref LoginGrid, "نسخه-داروخانه", false, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);            
            XLogin.Children.Clear();
            loginUC = new Login.LoginUC();
            XLogin.Children.Add(loginUC);
        }
        private async void Logout()
        {
            await SignalR.ConnectingLogout();
        }
        private void NoskhesItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref NoskhesGrid, "نسخه ها", true, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);            
        }

        private void FinanceItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref FinanceGrid, "کیف پول", true, MaterialDesignThemes.Wpf.PackIconKind.Wallet);
            FinanceGrid.Children.Clear();
            financeUC = new Finance.FinanceUC();
            financeUC.ShowOn();
            FinanceGrid.Children.Add(financeUC);
        }

        private void StarItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StarGrid.Children.Clear();
            starUC = new Star.StarUC();
            StarGrid.Children.Add(starUC);
            starUC.ShowOn();
            GridsShow(ref StarGrid, "رتبه بندی", true, MaterialDesignThemes.Wpf.PackIconKind.Star);
        }

        private void SettingsItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref SettingsGrid, "تنظیمات", true, MaterialDesignThemes.Wpf.PackIconKind.Settings);
        }    

        private void ServerStatusButton_Click(object sender, RoutedEventArgs e)
        {
            StatusGrid.Children.Clear();
            statusUC = new Status.StatusUC();
            StatusGrid.Children.Add(statusUC);
            GridsShow(ref StatusGrid, "Status", true, MaterialDesignThemes.Wpf.PackIconKind.LanConnect);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            GridsShow(ref AboutGrid, "About Us", true, MaterialDesignThemes.Wpf.PackIconKind.Contacts);
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProfileGrid.Children.Clear();
                profileuc = new ProfileUC();
                profileuc.Load_User();
                ProfileGrid.Children.Add(profileuc);
                GridsShow(ref ProfileGrid, "Profile", true, MaterialDesignThemes.Wpf.PackIconKind.Account);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void AboutGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NoskhesGrid.Visibility = Visibility.Hidden;
            FinanceGrid.Visibility = Visibility.Hidden;
            StarGrid.Visibility = Visibility.Hidden;
            SettingsGrid.Visibility = Visibility.Hidden;
            StatusGrid.Visibility = Visibility.Hidden;
            DoingDetailGrid.Visibility = Visibility.Hidden;
            AboutGrid.Visibility = Visibility.Hidden;
            AcceptForm.Visibility = Visibility.Hidden;
            WindowTitle.Text = "نسخه-داروخانه";
            TitleIco.Visibility = Visibility.Hidden;
        }
        public void GridsShow(ref Grid GridToShow, string TitleText,bool IcoShow , MaterialDesignThemes.Wpf.PackIconKind packIconKind)
        {
            try
            {
                List<Grid> ListOfGrids = new List<Grid>() { NoskhesGrid , FinanceGrid, StarGrid, SettingsGrid, StatusGrid, DoingDetailGrid, AboutGrid, LoginGrid , ProfileGrid , DrugDetailForm };
                GridToShow.Visibility = Visibility.Visible;
                foreach (var item in ListOfGrids)
                {
                    if (GridToShow.Name != item.Name)
                        item.Visibility = Visibility.Hidden;
                }
                WindowTitle.Text = TitleText;
                if (IcoShow)
                {
                    TitleIco.Visibility = Visibility.Visible;
                    TitleIco.Kind = packIconKind;
                }
                else
                {
                    TitleIco.Visibility = Visibility.Hidden;
                }
                //for close all objects that children of the XDingdetail To send an object from the caller again
                if (GridToShow.Name == DoingDetailGrid.Name)
                    XDingdetail.Children.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async void ONOFFButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository repo = new Repository();
                bool res = await repo.ToggleONOFF(true);
                if(res)
                {
                    var bc = new BrushConverter();
                    ONOFFButton.Background = (Brush)bc.ConvertFrom("#FF1BD188");
                    ONOFFButton.ToolTip = "شدن ، از دسترس خارج می شوید OFF در صورت";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ONOFFButton_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository repo = new Repository();
                bool res = await repo.ToggleONOFF(false);
                if(!res)
                {
                    var bc = new BrushConverter();
                    ONOFFButton.Background = (Brush)bc.ConvertFrom("#FFD1501B");
                    ONOFFButton.ToolTip = "شدن ، در دسترس قرار می گیرید ON در صورت";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
