using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Noskhes.Dones
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _Code;

        public string Code
        {
            get { return _Code; }
            set
            {
                _Code = value;
                OnPropertyChanged("Code");
            }
        }
        private string _PharmacyName;

        public string PharmacyName
        {
            get { return _PharmacyName; }
            set
            {
                _PharmacyName = value;
                OnPropertyChanged("PharmacyName");
            }
        }
        private decimal _TotalPrice;

        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                _TotalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        private int _TimeOfPacking;

        public int TimeOfPacking
        {
            get { return _TimeOfPacking; }
            set
            {
                _TimeOfPacking = value;
                OnPropertyChanged("TimeOfPacking");
            }
        }
        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }



    }
}
