using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Controller;

namespace noskhe_drugstore_app
{
    public class CurrentUser
    {
        public static string UPI { get; set; }
        public static string Email { get; set; }
        public async void SetDATAasync(string email)
        {
            try
            {
                Email = email;
                Repository repo = new Repository();
                UPI = await repo.GetUPI(Email);
            }
            catch (Exception)
            {
                
            }
        }

    }
}
