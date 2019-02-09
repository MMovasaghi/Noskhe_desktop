using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.BaseClasses
{
    public class DrugBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductPictureUrl { get; set; }
        public int Number { get; set; }
    }
}
