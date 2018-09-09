using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class NOT_RESPONDING : Exception
    {
        public NOT_RESPONDING()
        {
        }

        public NOT_RESPONDING(string message) : base(message)
        {
        }

        public NOT_RESPONDING(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
