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

        private void PriceItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double Price = Double.Parse(PriceItem.Text);
                if (Price > 9999999 || Price <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                PriceItem.Text = "";
            }
        }
    }
}
