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

namespace noskhe_drugstore_app.Finance
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class FinanceUC : UserControl
    {

        public FinanceUC()
        {
            InitializeComponent();

        }

        private void FinanceRe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FinanceRepo.Visibility = Visibility.Visible;
            CachOutRepo.Visibility = Visibility.Hidden;
        }

        private void CachOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FinanceRepo.Visibility = Visibility.Hidden;
            CachOutRepo.Visibility = Visibility.Visible;
        }
    }
}
