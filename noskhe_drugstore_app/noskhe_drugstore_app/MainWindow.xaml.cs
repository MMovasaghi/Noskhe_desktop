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

namespace noskhe_drugstore_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        AcceptUC acceptUC = new AcceptUC();
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
        private void ONOFFcatchButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        private void ButtonPopuplogout_Click(object sender, RoutedEventArgs e)
        {
            GridsShow(ref LoginGrid, "نسخه-داروخانه", false, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);
        }
        private void NoskhesItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref NoskhesGrid, "نسخه ها", true, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);
        }

        private void FinanceItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref FinanceGrid, "کیف پول", true, MaterialDesignThemes.Wpf.PackIconKind.Wallet);
        }

        private void StarItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref StarGrid, "رتبه بندی", true, MaterialDesignThemes.Wpf.PackIconKind.Star);
        }

        private void SettingsItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridsShow(ref SettingsGrid, "تنظیمات", true, MaterialDesignThemes.Wpf.PackIconKind.Settings);
        }    

        private void ServerStatusButton_Click(object sender, RoutedEventArgs e)
        {
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
                ProfileUC profileuc = new ProfileUC();
                ProfileGrid.Children.Add(profileuc);
                GridsShow(ref ProfileGrid, "Profile", true, MaterialDesignThemes.Wpf.PackIconKind.Account);
            }
            catch (Exception)
            {
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

        private void AcceptShow_Click(object sender, RoutedEventArgs e)
        {
            NoskheForFirstNotificationOnDesktop noskheForFirstNotificationOnDesktop = new NoskheForFirstNotificationOnDesktop()
            {
                Picture_Urls = new List<string>()
                {
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsgKWaWvMfgSmQjJBETlectexGQ4qM_Yf4eiP44iWKUqBASfGvUA",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSGDusBHcHurXuTpvVG2PMu44PjcGAMDjN0QsybEkwwg4Eo1CR",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNn35JV-qkvadDzEBizt0v1jYNxbapM6evnbKPUjzlhrGCcq2_",
                },
                Cosmetics = new List<CosmeticOutput>()
                {
                    new CosmeticOutput()
                    {
                        Name = "Lipstick",
                        Number = 3,
                        Price = 100000,
                        CosmeticId = 74,
                        ProductPictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUFevN_-QwofXToQIEvhGXZ595uE1D23T_jDe3s_s92nP9fg6y",
                    },
                    new CosmeticOutput()
                    {
                        Name = "Remel",
                        Number = 3,
                        Price = 200000,
                        CosmeticId = 89,
                        ProductPictureUrl = "https://assets.fishersci.com/TFS-Assets/MBD/product-images/F103904~p.eps-650.jpg",
                    }

                },
                Medicions = new List<MedicineOutput>()
                {
                    new MedicineOutput()
                    {
                        Name = "Asetaminofen",
                        Number = 10,
                        Price = 200000,
                        MedicineId = 186,
                        ProductPictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRg6DW40E6_NSu4FAj0gh8JPKAl-81fiOKQHcbR6QjSuSeH_9zV",
                    },
                    new MedicineOutput()
                    {
                        Name = "Aspirin",
                        Number = 7,
                        Price = 600000,
                        MedicineId = 78,
                        ProductPictureUrl = "https://cdn1.medicalnewstoday.com/content/images/articles/301/301766/bottle-of-aspirin.jpg",
                    },
                },
                Customer = new CustomerOutput()
                {
                    FirstName = "محمدحسین",
                    LastName = "موثقی نیا",
                    Gender = Models.Gender.Male,
                    Phone = "09122184357",
                    ProfilePictureUrl = "https://static.evand.net/images/description/original/26bab6a266285f35db954f9485b0443c.jpg?x-oss-process=image/resize,h_200,w_200"
                },
            };
            SignalR.MessageNotification(noskheForFirstNotificationOnDesktop);
        }
        public void GridsShow(ref Grid GridToShow,string TitleText,bool IcoShow , MaterialDesignThemes.Wpf.PackIconKind packIconKind)
        {
            try
            {
                List<Grid> ListOfGrids = new List<Grid>() { NoskhesGrid, FinanceGrid, StarGrid, SettingsGrid, StatusGrid, DoingDetailGrid, AboutGrid, LoginGrid , ProfileGrid , DrugDetailForm };
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ONOFFButton_Click(object sender, RoutedEventArgs e)
        {           

            if (ONOFFButton.Content.ToString() == "Enable")
            {
                MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که می خواهید وضعیت داروخانه را به حالت خاموش تغییر دهید؟", "Disabling", MessageBoxButton.YesNo);
                if (mbox == MessageBoxResult.Yes)
                {
                    ONOFFButton.Content = "Disable";
                    var bc = new BrushConverter();                   
                    ONOFFButton.Background = (Brush)bc.ConvertFrom("#FFD1501B");
                    ONOFFButton.BorderBrush = (Brush)bc.ConvertFrom("#FFD1501B");
                }
            }
            else if (ONOFFButton.Content.ToString() == "Disable")
            {
                MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که می خواهید وضعیت داروخانه را به حالت روشن تغییر دهید؟", "Enabling", MessageBoxButton.YesNo);
                if (mbox == MessageBoxResult.Yes)
                {
                    ONOFFButton.Content = "Enable";
                    var bc = new BrushConverter();
                    ONOFFButton.Background = (Brush)bc.ConvertFrom("#FF1BD188");
                    ONOFFButton.BorderBrush = (Brush)bc.ConvertFrom("#FF1BD188");
                }
            }
        }
        
        
    }
}
