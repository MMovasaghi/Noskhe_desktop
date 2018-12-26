using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace noskhe_drugstore_app.AcceptPH
{
    /// <summary>
    /// Interaction logic for ShowImagePanel.xaml
    /// </summary>
    public partial class ShowImagePanel : UserControl
    {
        public string ImageUrl { get; set; }
        public ShowImagePanel()
        {
            InitializeComponent();
        }

        private void XShowImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(ImageUrl);
        }
    }
}
