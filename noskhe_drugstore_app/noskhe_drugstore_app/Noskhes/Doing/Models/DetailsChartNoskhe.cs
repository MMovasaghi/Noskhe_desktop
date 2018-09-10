using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Noskhes.Doing.Models
{
    public class DetailsChartNoskhe : INotifyPropertyChanged
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private decimal _Value;

        public decimal Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                OnPropertyChanged("Value");
                AllMoney = (value * Number);
                OnPropertyChanged("AllMoney");
            }
        }
        private int _Number;

        public int Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
                OnPropertyChanged("Number");
                AllMoney = (value * Value);
                OnPropertyChanged("AllMoney");
            }
        }
        private decimal _AllMoney;

        public decimal AllMoney
        {
            get { return _AllMoney; }
            set
            {
                _AllMoney = value;                
            }
        }
        public DetailsChartNoskhe()
        {
            AllMoney = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
