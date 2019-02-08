using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models
{
    public class Notation
    {
        public int NotationId { get; set; }
        public BrandType BrandPreference { get; set; }
        public bool HasPregnancy { get; set; }
        public bool HasOtherDiseases { get; set; }
        public string Description { get; set; }        
        public int ShoppingCartId { get; set; }
    }
}
