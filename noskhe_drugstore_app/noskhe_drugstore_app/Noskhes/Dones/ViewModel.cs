using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace noskhe_drugstore_app.Noskhes.Dones
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Models.Minimals.Output.Order> order { set; get; }
        public ViewModel()
        {
            
        }
        public async void GetData()
        {            
            try
            {
                Controller.Repository repo = new Controller.Repository();
                order = await repo.Get_AllOrders();
                foreach (var item in order)
                {
                    Items1 = new ObservableCollection<Model>()
                    {
                        new Model()
                        {
                            PharmacyName = item.PharmacyName,
                            TotalPrice = item.TotalPriceWithoutShippingCost,
                            TimeOfPacking = item.PackingTime,
                            Code = item.UOI,
                            Date = item.Date,
                            Description = item.Description,
                        },
                    };
                }
            }
            catch (System.Exception)
            {

            }           

        }

        private ObservableCollection<Model> _Items1;
        public  ObservableCollection<Model> Items1
        {
            get { return _Items1; }
            set
            {
                _Items1 = value;
                OnPropertyChanged("Items1");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}