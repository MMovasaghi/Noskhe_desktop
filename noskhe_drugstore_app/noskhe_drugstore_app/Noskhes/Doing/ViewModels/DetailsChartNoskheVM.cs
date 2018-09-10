using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Noskhes.Doing.Models;

namespace noskhe_drugstore_app.Noskhes.Doing.ViewModels
{
    class DetailsChartNoskheVM
    {
        private List<DetailsChartNoskhe> _Details;

        public List<DetailsChartNoskhe> Details
        {
            get { return _Details; }
            set { _Details = value; }
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
