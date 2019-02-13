using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Models.CustomExceptions
{
    class PICTURE_FAILURE : Exception
    {
        public PICTURE_FAILURE()
        {
        }

        public PICTURE_FAILURE(string message) : base(message)
        {
        }

        public PICTURE_FAILURE(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
