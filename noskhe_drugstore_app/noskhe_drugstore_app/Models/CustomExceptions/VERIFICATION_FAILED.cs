using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class VERIFICATION_FAILED : Exception
    {
        public VERIFICATION_FAILED()
        {
        }

        public VERIFICATION_FAILED(string message) : base(message)
        {
        }

        public VERIFICATION_FAILED(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
