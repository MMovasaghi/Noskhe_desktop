using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Star
{
    internal class StarViewModel
    {
        private StarModel _starModel;
        public StarModel starModel
        {
            get { return _starModel; }
            set { _starModel = value; }
        }
        public StarViewModel()
        {
            starModel = new StarModel
            {
                Value = new Random().Next(0, 100),
            };

        }
    }
}
