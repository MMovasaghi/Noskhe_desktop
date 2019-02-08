using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace noskhe_drugstore_app.Noskhes.Dones
{
    /// <summary>
    /// Interaction logic for SellDetailUC.xaml
    /// </summary>
    public partial class DonesDetailUC : UserControl
    {
        public List<Models.Minimals.Output.Order> order { set; get; }
        public DonesDetailUC()
        {
            InitializeComponent();
        }

        private void ReloadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowOnGrid();
        }
        public async void ShowOnGrid()
        {
            try
            {
                Controller.Repository repo = new Controller.Repository();
                order = await repo.Get_AllOrders();

                foreach (var item in order)
                {

                    DonesDetail_DataGrid.Items.Add(new
                    {
                        FirstName = "ali",
                        LastName = "hasan",


                    });
                }
            }
            catch (Exception)
            {

            }
            
            
        }
    }
}
