using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Controller
{
    public static class ServerURL
    {
        public static string Main_Server_url = "http://192.168.1.58:5000"; 
        public static string Hub_Server_url = Main_Server_url + "/NotificationHub/";
        public static string ROUTE = "/desktop-api/pharmacy";
        public static string API_KEY_TYPE = "desktop-api-key";
        public static string API_KEY_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
        public static string AUTH_TYPE = "Authorization";
        public static string AUTH_VALUE = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1NDQ1OTgzNDcsImV4cCI6MTU0NDY4NDc0NywiaWF0IjoxNTQ0NTk4MzQ3fQ.9HFRayDKcWZ17noOHeX7leEQgcRoliG-MAd2rbsr-9Q";
        public static string API_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
    }
}
