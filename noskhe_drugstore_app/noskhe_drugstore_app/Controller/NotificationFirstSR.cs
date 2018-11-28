using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app
{
    public class NotificationFirstSR
    {
        public List<string> Url { get; set; }
        public List<WithOutNoskheFist> ListWithOutNoskhe { get; set; }

    }
    public class WithOutNoskheFist
    {
        public int Number { get; set; }
        public string Nlist { get; set; }
    }
}
