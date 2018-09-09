using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class DATA_IS_NOT_AVAILABE : Exception
    {
        public DATA_IS_NOT_AVAILABE()
        {
        }

        public DATA_IS_NOT_AVAILABE(string message) : base(message)
        {
        }

        public DATA_IS_NOT_AVAILABE(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
