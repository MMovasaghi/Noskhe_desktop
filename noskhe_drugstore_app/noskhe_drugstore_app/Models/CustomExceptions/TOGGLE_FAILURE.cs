using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class TOGGLE_FAILURE : Exception
    {
        public TOGGLE_FAILURE()
        {
        }

        public TOGGLE_FAILURE(string message) : base(message)
        {
        }

        public TOGGLE_FAILURE(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
