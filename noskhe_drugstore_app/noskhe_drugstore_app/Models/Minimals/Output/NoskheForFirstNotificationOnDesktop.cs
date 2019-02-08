﻿using System.Collections.Generic;

namespace noskhe_drugstore_app.Models.Minimals.Output
{
    public class NoskheForFirstNotificationOnDesktop
    {
        public List<string> Picture_Urls { set; get; }
        public List<CosmeticOutput> Cosmetics { set; get; }
        public List<MedicineOutput> Medicions { set; get; }
        public CustomerOutput Customer { get; set; }
        public decimal SumAllPrice { get; set; }
        public long NumberOfWithOutNoskhe { get; set; }
        public int NumberOfNoskhe { get; set; }
        public Notation Notation { get; set; }
    }
}
