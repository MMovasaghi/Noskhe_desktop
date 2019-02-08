using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Controller
{
    public static class ConnectionUrls
    {
        public static string Main_Server_url = "http://192.168.1.59:5000"; 
        public static string Hub_Server_url = Main_Server_url + "/NotificationHub/";
        public static string ROUTE = "/desktop-api/pharmacy";
        public static string API_KEY_TYPE = "desktop-api-key";
        public static string API_KEY_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
        public static string AUTH_TYPE = "Authorization";
        public static string AUTH_VALUE = Token.Bearer + Token.Value;
    }
    public static class Token
    {
        public static string Bearer = "Bearer ";
        public static string Value = "";
    }

}
