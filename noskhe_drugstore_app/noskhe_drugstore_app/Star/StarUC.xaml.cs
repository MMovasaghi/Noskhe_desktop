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
        public StarUC()
        {
            InitializeComponent();
        }
        public async void ShowOn()
        {
            try
            {
                Controller.Repository repository = new Controller.Repository();
                Models.Minimals.Output.Score score = await repository.Get_Score();

                Rank.Text = score.RankAmongPharmacies.ToString();
                CustomerSatisfaction.Text = score.CustomerSatisfaction.ToString() + " %";
                AverageTime.Text = score.PackingAverageTimeInSeconds.ToString() + "\'";
                RateMap.Value = score.CustomerSatisfaction;
            }
            catch (Exception)
            {
                Rank.Text = (0).ToString();
                CustomerSatisfaction.Text = 0 + " %";
                AverageTime.Text = 0 + "\'";
                RateMap.Value = 0;
            }
        }
    }
}
