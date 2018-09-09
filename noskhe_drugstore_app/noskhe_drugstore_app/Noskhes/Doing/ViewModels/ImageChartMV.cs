using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Noskhes.Doing.Models;

namespace noskhe_drugstore_app.Noskhes.Doing.ViewModels
{
    public class ImageChartMV
    {
        private ImageChartModels _ObjectImage;

        public ImageChartModels ObjIm
        {
            get { return _ObjectImage; }
            set { _ObjectImage = value; }
        }
    }
}
