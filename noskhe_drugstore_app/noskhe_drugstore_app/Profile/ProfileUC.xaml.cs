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
using noskhe_drugstore_app.Models.Minimals.Output;
using noskhe_drugstore_app.Controller;

namespace noskhe_drugstore_app.Profile
{
    /// <summary>
    /// Interaction logic for NoskhesUC.xaml
    /// </summary>
    public partial class ProfileUC : UserControl
    {
        private string ProfilePictureUrl;
        public ProfileUC()
        {
            InitializeComponent();            
        }

        private void Reload_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Load_User();
            this.Cursor = Cursors.Arrow;
        }
        public async void Load_User()
        {
            try
            {
                Repository repo = new Repository();
                var p = await repo.Get_Pharmacy_Info();

                PHname.Text = p.Name;
                PHnum.Text = p.Phone;
                PHemail.Text = p.Email;
                PHcredit.Text = p.Credit.ToString();
                PHaddress.Text = p.Address;
                PHmanager.Text = p.ManagerName;
                ProfilePictureUrl = p.ProfilePictureUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
