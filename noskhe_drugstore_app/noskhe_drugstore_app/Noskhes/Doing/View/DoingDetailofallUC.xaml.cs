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
using noskhe_drugstore_app.Noskhes.Doing.Models;

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for FinanceDetailUC.xaml
    /// </summary>
    public partial class DoingDetailofallUC : UserControl
    {
        public DoingSicksMV doingSicks = new DoingSicksMV();
        public ImageChartMV imageChart = new ImageChartMV();
        public noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop NoskheForFirstNotificationOnDesktop { get; set; }
        public DoingDetailofallUC()
        {
            InitializeComponent();
            DataContext = doingSicks;
        }
        int a = 0;
        private void BackButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).GridsShow(ref (window as MainWindow).NoskhesGrid, "نسخه ها", true, MaterialDesignThemes.Wpf.PackIconKind.ContentPaste);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که نسخه پیچیده شده است ؟", "Warrning", MessageBoxButton.YesNo);

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        public void ShowOnScreen(noskhe_drugstore_app.Models.Minimals.Output.NoskheForFirstNotificationOnDesktop arg , ref TextBlock df)
        {
            textbox = df;

            NoskheForFirstNotificationOnDesktop = arg;
            SickFirstName.Text = NoskheForFirstNotificationOnDesktop.Customer.FirstName;
            SickLastName.Text = NoskheForFirstNotificationOnDesktop.Customer.LastName;
            SickPhone.Text = NoskheForFirstNotificationOnDesktop.Customer.Phone;

            PayAll.Text = NoskheForFirstNotificationOnDesktop.SumAllPrice.ToString();

            //add images with out noskhe
            foreach (var item in NoskheForFirstNotificationOnDesktop.Picture_Urls)
            {
                AddImageData(item);
            }
            int X = 0;
            foreach (var item in NoskheForFirstNotificationOnDesktop.Cosmetics)
            {
                X++;
                AddWithoutNoskhe(X, item.Name, item.Number, item.Price);
            }
            foreach (var item in NoskheForFirstNotificationOnDesktop.Medicions)
            {
                X++;
                AddWithoutNoskhe(X, item.Name, item.Number, item.Price);
            }


            //delivery data
        }
        public void AddImageData(string URLIMAGE)
        {
            a++;
            try
            {
                var image = new Image();
                var fullFilePath = URLIMAGE;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;

                NoskheChart noskheChart = new NoskheChart();
                noskheChart.imageMV.ObjIm = new Models.ImageChartModels() { ImageUrl = fullFilePath, Price = 100 };
                noskheChart.ImageItem.Children.Add(image);
                noskheChart.RowNumber.Text = a.ToString();
                Xpanel.Children.Add(noskheChart);

            }
            catch (Exception)
            {

            }
        }
        public void AddWithoutNoskhe(int Row,string Name,int Number,decimal Price)
        {
            a++;
            try
            {

                //With-Out-Noskhe-
                withoutNoskheCU withoutNoskheCU = new withoutNoskheCU();
                withoutNoskheCU.RowNumber.Text = Row.ToString();
                withoutNoskheCU.Name.Text = Name;
                withoutNoskheCU.Number.Text = Number.ToString();
                withoutNoskheCU.money = Price;
                withoutNoskheCU.Price.Text = Price.ToString();
                

                XWithOutNoskhePanel.Children.Add(withoutNoskheCU);

            }
            catch (Exception)
            {

            }
        }

        private void CheckWithoutNoskheToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbox = MessageBox.Show("آیا از مبالغ وارد شده برای دارو ها مطمئن هستید ؟\n.در صورت تایید امکان تغییر قیمت ها به هیچ وجه امکان پذیر نمی باشد", "Warrning", MessageBoxButton.YesNo);

            if(mbox == MessageBoxResult.Yes)
            {
                try
                {
                    NoskheForFirstNotificationOnDesktop.SumAllPrice = 0;

                    foreach (var item in XWithOutNoskhePanel.Children)
                    {
                        if (item.GetType() == typeof(withoutNoskheCU))
                        {
                            NoskheForFirstNotificationOnDesktop.SumAllPrice += (((withoutNoskheCU)item).money * decimal.Parse(((withoutNoskheCU)item).Number.Text));
                            ((withoutNoskheCU)item).Price.IsEnabled = false;
                        }
                    }
                    var bc = new BrushConverter();
                    CheckWithoutNoskheToggleButton.BorderBrush = (Brush)bc.ConvertFrom("#FF27B339");
                    CheckWithoutNoskheToggleButton.Background = (Brush)bc.ConvertFrom("#FF27B339");
                    CheckWithoutNoskheToggleKind.Kind = MaterialDesignThemes.Wpf.PackIconKind.Check;
                    PayAll.Text = NoskheForFirstNotificationOnDesktop.SumAllPrice.ToString();
                    CheckWithoutNoskheToggleButton.IsEnabled = false;

                    textbox.Text = NoskheForFirstNotificationOnDesktop.SumAllPrice.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                }
                
            }
            
        }
    }
}
