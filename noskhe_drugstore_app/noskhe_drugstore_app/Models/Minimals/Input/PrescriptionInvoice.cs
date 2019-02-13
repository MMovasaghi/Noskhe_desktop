using System.Collections.Generic;

namespace noskhe_drugstore_app.Models.Minimals.Input
{
    public class PrescriptionInvoice
    {
        public int ShoppingCartId { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}