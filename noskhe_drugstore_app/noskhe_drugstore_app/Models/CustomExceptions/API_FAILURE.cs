using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class API_FAILURE : Exception
    {
        public API_FAILURE()
        {
        }

        public API_FAILURE(string message) : base(message)
        {
        }

        public API_FAILURE(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
