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
        NoskheImageDetails noskheImageDetails = new NoskheImageDetails();
        public string URL_IMAGE { get; set; }
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
                var image = new Image();
                var fullFilePath = imageMV.ObjIm.ImageUrl;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                image.Source = bitmap;
                noskheImageDetails.ImageItem.Children.Add(image);
                noskheImageDetails.URL = fullFilePath;
                //to show on window
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).DrugDetailForm.Visibility = Visibility.Visible;
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
