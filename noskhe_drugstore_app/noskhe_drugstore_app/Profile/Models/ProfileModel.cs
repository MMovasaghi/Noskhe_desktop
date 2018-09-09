using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Models.Minimals.Output;

namespace noskhe_drugstore_app.Profile.Models
{
    public class ProfileModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private Pharmacy _pharmacy;

        public Pharmacy pharmacy
        {
            get { return _pharmacy; }
            set { _pharmacy = value; OnPropertyChanged("pharmacy"); }
        }
    }
}
