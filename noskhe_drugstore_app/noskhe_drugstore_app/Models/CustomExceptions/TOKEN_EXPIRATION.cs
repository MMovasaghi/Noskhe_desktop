using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class TOKEN_EXPIRATION : Exception
    {
        public TOKEN_EXPIRATION()
        {
        }

        public TOKEN_EXPIRATION(string message) : base(message)
        {
        }

        public TOKEN_EXPIRATION(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
