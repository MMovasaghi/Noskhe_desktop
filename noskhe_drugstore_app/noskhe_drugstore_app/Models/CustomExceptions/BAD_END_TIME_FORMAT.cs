using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class BAD_END_TIME_FORMAT : Exception
    {
        public BAD_END_TIME_FORMAT()
        {
        }

        public BAD_END_TIME_FORMAT(string message) : base(message)
        {
        }

        public BAD_END_TIME_FORMAT(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
