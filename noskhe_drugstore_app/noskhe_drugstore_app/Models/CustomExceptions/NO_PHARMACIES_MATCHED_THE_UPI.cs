using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class NO_PHARMACIES_MATCHED_THE_UPI : Exception
    {
        public NO_PHARMACIES_MATCHED_THE_UPI()
        {
        }

        public NO_PHARMACIES_MATCHED_THE_UPI(string message) : base(message)
        {
        }

        public NO_PHARMACIES_MATCHED_THE_UPI(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
