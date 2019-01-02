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
    /// Interaction logic for withoutNoskheCU.xaml
    /// </summary>
    public partial class withoutNoskheCU : UserControl
    {
        public decimal money { set; get; }
        public withoutNoskheCU()
        {
            InitializeComponent();            
        }        
        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal pricenumber = decimal.Parse(Price.Text);
                money = pricenumber;
            }
            catch (Exception)
            {
                Price.Text = "";
            }
        }
    }
}
