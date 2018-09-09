using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace noskhe_drugstore_app.AcceptPH.Models
{
    public class TimerACModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _sec;
        public int sec
        {
            get { return _sec; }
            set
            {
                _sec = value;
                OnPropertyChanged("sec");
            }
        }
        private Brush _TimerAlert;
        public Brush TimerAlert
        {
            get { return _TimerAlert; }
            set
            {
                _TimerAlert = value;
                OnPropertyChanged("TimerAlert");
            }
        }


    }
}
