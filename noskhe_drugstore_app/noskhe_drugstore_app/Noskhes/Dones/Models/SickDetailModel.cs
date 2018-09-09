using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Persons;

namespace noskhe_drugstore_app.Noskhes.Dones.Models
{
    class SickDetailModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private SickPerson _sickPerson;
        public SickPerson sickPerson
        {
            get { return _sickPerson; }
            set
            {
                _sickPerson = value;
                OnPropertyChanged("sickPerson");
            }
        }

    }
}
