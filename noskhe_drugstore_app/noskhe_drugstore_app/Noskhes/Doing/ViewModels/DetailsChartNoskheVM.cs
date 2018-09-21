using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Noskhes.Doing.Models;
using System.ComponentModel;

namespace noskhe_drugstore_app.Noskhes.Doing.ViewModels
{
    public class DetailsChartNoskheVM : INotifyPropertyChanged
    {
        private List<DetailsChartNoskhe> _Details;

        public List<DetailsChartNoskhe> Details
        {
            get { return _Details; }
            set { _Details = value; }
        }

        private decimal _allMoney;

        public decimal allMoney
        {
            get { return _allMoney; }
            set { _allMoney = value; OnPropertyChanged("allMoney"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public DetailsChartNoskheVM()
        {
            Details = new List<DetailsChartNoskhe>();
        }
        public void AddData(DetailsChartNoskhe d)
        {
            Details.Add(d);
        }
    }
}
