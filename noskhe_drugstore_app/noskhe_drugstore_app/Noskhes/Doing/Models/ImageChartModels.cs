using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Noskhes.Doing.Models
{
    public class ImageChartModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _Price;
        public int Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged("Price");
            }
        }

        private string _ImageUrl;
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set
            {
                _ImageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }
    }
}
