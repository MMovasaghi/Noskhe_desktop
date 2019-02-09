using System;
using System.Collections.Generic;

namespace noskhe_drugstore_app.Models
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        /*
            1 Prescription
         */
         public int PrescriptionId { get; set; }
         public Prescription Prescription { get; set; }
    }
}