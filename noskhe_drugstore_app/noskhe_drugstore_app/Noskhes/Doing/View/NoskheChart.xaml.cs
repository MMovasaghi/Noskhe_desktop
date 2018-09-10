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
using noskhe_drugstore_app.Noskhes.Doing.ViewModels;
using System.Diagnostics;

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for NoskheChart.xaml
    /// </summary>
    public partial class NoskheChart : UserControl
    {
        public ImageChartMV imageMV = new ImageChartMV();
        public NoskheChart()
        {
            InitializeComponent();
            DataContext = imageMV;
        }
        private void ImageItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start(imageMV.ObjIm.ImageUrl);
        }

        private void Details_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                NoskheImageDetails noskheImageDetails = new NoskheImageDetails();


                var image = new Image();
                var fullFilePath = @"https://cdn.newsapi.com.au/image/v1/9fdbf585d17c95f7a31ccacdb6466af9";

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;

                //NoskheChart noskheChart = new NoskheChart();
                //noskheChart.imageMV.ObjIm = new Models.ImageChartModels() { ImageUrl = fullFilePath, Price = 100 };
                noskheImageDetails.ImageItem.Children.Add(image);
                //to show on window
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).GridsShow(ref (window as MainWindow).DrugDetailForm, "", false, MaterialDesignThemes.Wpf.PackIconKind.AccessPoint);
                        (window as MainWindow).XDrugDetailForm.Children.Add(noskheImageDetails);

                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
