using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class START_TIME_IS_GREATER_THAN_END_TIME : Exception
    {
        public START_TIME_IS_GREATER_THAN_END_TIME()
        {
        }

        public START_TIME_IS_GREATER_THAN_END_TIME(string message) : base(message)
        {
        }

        public START_TIME_IS_GREATER_THAN_END_TIME(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
