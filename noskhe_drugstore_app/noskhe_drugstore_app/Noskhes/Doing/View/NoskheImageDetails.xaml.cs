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

namespace noskhe_drugstore_app.Noskhes.Doing.View
{
    /// <summary>
    /// Interaction logic for NoskheImageDetails.xaml
    /// </summary>
    public partial class NoskheImageDetails : UserControl
    {
        List<Sample> samples;
        public NoskheImageDetails()
        {
            InitializeComponent();
            samples = new List<Sample>();
            DrugDetailChart.ItemsSource = samples;
        }

        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {

            samples.Add(new Sample() { Name = "", Value = "" });
            //DrugDetailChart.Items.Add(samples);
        }

        private void AcceptChange_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Sample
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

}
