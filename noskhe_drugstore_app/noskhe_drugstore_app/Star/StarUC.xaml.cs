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

namespace noskhe_drugstore_app.Star
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class StarUC : UserControl
    {
        StarViewModel starView = new StarViewModel();
        public StarUC()
        {
            InitializeComponent();
            DataContext = starView;

            if(starView.score != null)
            {
                Rank.Text = starView.score.RankAmongPharmacies.ToString();
                CustomerSatisfaction.Text = starView.score.CustomerSatisfaction.ToString() + " %";
                AverageTime.Text = starView.score.PackingAverageTimeInSeconds.ToString() + "\'";
            }
            else
            {
                Rank.Text = (0).ToString();
                CustomerSatisfaction.Text = 0 + " %";
                AverageTime.Text = 0 + "\'";
            }
            
        }
    }
}
