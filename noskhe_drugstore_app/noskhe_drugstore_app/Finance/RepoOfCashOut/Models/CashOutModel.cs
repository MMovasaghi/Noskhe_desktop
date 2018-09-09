using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Finance.RepoOfCashOut.Models
{
    public class CashOutModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private CashOutTBL _cashouttbl;

        public CashOutTBL cashouttbl
        {
            get { return _cashouttbl; }
            set
            {
                _cashouttbl = value;
                OnPropertyChanged("cashouttbl");
            }
        }

    }
}
