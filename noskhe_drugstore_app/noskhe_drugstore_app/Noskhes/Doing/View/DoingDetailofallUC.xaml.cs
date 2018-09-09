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

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for FinanceDetailUC.xaml
    /// </summary>
    public partial class DoingDetailofallUC : UserControl
    {
        public DoingSicksMV doingSicks = new DoingSicksMV();
        public ImageChartMV imageChart = new ImageChartMV();
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
            a++;
            try
            {
                var image = new Image();
                var fullFilePath = @"https://cdn.newsapi.com.au/image/v1/9fdbf585d17c95f7a31ccacdb6466af9";

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;

                NoskheChart noskheChart = new NoskheChart();
                noskheChart.imageMV.ObjIm = new Models.ImageChartModels() { ImageUrl = fullFilePath, Price = 100 };
                noskheChart.ImageItem.Children.Add(image);
                noskheChart.PriceItem.Text = "100";
                noskheChart.RowNumber.Text = a.ToString();
                Xpanel.Children.Add(noskheChart);
            }
            catch (Exception)
            {

            }
            MessageBoxResult mbox = MessageBox.Show("آیا مطمئن هستید که نسخه پیچیده شده است ؟", "Warrning", MessageBoxButton.YesNo);

        }
    }
}
