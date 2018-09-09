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

namespace noskhe_drugstore_app.Finance.RepoInChart
{
    /// <summary>
    /// Interaction logic for SellDetailUC.xaml
    /// </summary>
    public partial class SellDetailUC : UserControl
    {
        public SellDetailUC()
        {
            InitializeComponent();
            
        }

        private void ReloadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var sam = new sample { FirstNameItem = "علی", LastNameItem = "حسینی", AllSellItem = "10000", DateTimeItem = "1/1/1 - 12:00", OrderNumberItem = "N9238", SellDetailItem = "پشمام" };
            SellDetail_DataGrid.Items.Add(sam);

        }
    }
    class sample
    {
        public string FirstNameItem { get; set; }
        public string LastNameItem { get; set; }
        public string AllSellItem { get; set; }
        public string DateTimeItem { get; set; }
        public string OrderNumberItem { get; set; }
        public string SellDetailItem { get; set; }

        
    }
}
