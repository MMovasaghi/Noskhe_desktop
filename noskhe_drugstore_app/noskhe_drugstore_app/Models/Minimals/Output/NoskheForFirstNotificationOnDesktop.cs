﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.Minimals.Output
{
    public class NoskheForFirstNotificationOnDesktop
    {
        public List<string> Picture_Urls { set; get; }
        public Notation Notation { get; set; }
        public List<Cosmetic> Cosmetics { set; get; }
        public List<Medicine> Medicines { set; get; }
        public Customer Customer { get; set; }
        public decimal SumAllPrice { get; set; }
        public long NumberOfWithOutNoskhe { get; set; }
        public int NumberOfNoskhe { get; set; }
    }
}
