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
using noskhe_drugstore_app.Profile.ViewModels;
using noskhe_drugstore_app.Models.Minimals.Output;

namespace noskhe_drugstore_app.Profile
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class ProfileUC : UserControl
    {
        public ProfileVM objVM = new ProfileVM();
        public ProfileUC()
        {
            InitializeComponent();
            DataContext = objVM;
        }

        private void Reload_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            objVM.ReloadDataAsync(CurrentUser.UPI);
            this.Cursor = Cursors.Arrow;
        }
    }
}
