using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class DATABASE_FAILURE : Exception
    {
        public DATABASE_FAILURE()
        {
        }

        public DATABASE_FAILURE(string message) : base(message)
        {
        }

        public DATABASE_FAILURE(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
