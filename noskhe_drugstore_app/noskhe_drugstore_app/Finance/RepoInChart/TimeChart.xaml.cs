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
using LiveCharts;
using LiveCharts.Wpf;

namespace noskhe_drugstore_app.Finance.RepoInChart
{
    /// <summary>
    /// Interaction logic for TimeChart.xaml
    /// </summary>
    public partial class TimeChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public TimeChart()
        {
            InitializeComponent();
            
            try
            {
                SeriesCollection = new SeriesCollection();

                Labels = new[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه" };

                //modifying the series collection will animate and update the chart
                SeriesCollection.Add(new LineSeries
                {
                    Title = "دقیقه",
                    Values = new ChartValues<double> { 5, 3, 2, 4, 1000, 2, 7 },
                    PointForeground = Brushes.White,
                    PointGeometry = DefaultGeometries.Circle,
                });
            }
            catch (Exception)
            {
            }
            DataContext = this;

        }
    }
}
