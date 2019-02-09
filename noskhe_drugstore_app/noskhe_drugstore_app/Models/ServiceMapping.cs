using System;
using System.Collections.Generic;

namespace noskhe_drugstore_app.Models
{
    public class ServiceMapping
    {
        public int ServiceMappingId { get; set; }
        public List<Pharmacy> FoundPharmacies { get; set; }
        public int PrimativePharmacyIndex { get; set; } // for ease-of-use
        
        public PharmacyServiceStatus PharmacyServiceStatus { get; set; }
        public PharmacyCancellationReason PharmacyCancellationReason { get; set; }
        public DateTime PharmacyCancellationDate { get; set; }

        public bool CustomerCancellation { get; set; }
        public CustomerCancellationReason CustomerCancellationReason { get; set; }
        public DateTime CustomerCancellationDate { get; set; }
        
        // -- Nav Properties --
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }        
    }
}