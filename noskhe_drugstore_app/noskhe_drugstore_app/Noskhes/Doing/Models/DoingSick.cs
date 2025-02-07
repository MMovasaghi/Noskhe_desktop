﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Models.Minimals.Output;

namespace noskhe_drugstore_app.Noskhes.Doing.Models
{
    public class DoingSick : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private Customer _sickPerson;
        public Customer sickPerson
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
