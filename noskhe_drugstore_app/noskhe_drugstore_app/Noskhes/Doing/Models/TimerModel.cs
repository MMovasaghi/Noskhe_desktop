using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Noskhes.Doing.Models
{
    public class TimerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public TimerModel()
        {
            this.Sec = 0;
            this.Min = 0;
        }
        private int _Sec;
        public int Sec
        {
            get { return _Sec; }
            set
            {
                _Sec = value;
                OnPropertyChanged("Sec");
            }
        }
        private int _Min;
        public int Min
        {
            get { return _Min; }
            set
            {
                _Min = value;
                OnPropertyChanged("Min");
            }
        }
        private string _res;

        public string res
        {
            get { return _res; }
            set
            {
                _res = value;
                OnPropertyChanged("res");
            }
        }

    }
}
