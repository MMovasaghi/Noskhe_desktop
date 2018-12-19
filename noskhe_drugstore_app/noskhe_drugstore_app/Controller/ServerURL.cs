using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Controller
{
    public static class ServerURL
    {
        public static string Main_Server_url = "http://192.168.1.3:5000"; 
        public static string Hub_Server_url = Main_Server_url + "/NotificationHub/";
        public static string ROUTE = "/desktop-api/pharmacy";
        public static string API_KEY_TYPE = "desktop-api-key";
        public static string API_KEY_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
        public static string AUTH_TYPE = "Authorization";
        public static string AUTH_VALUE = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1NDUxOTc4OTEsImV4cCI6MTU0NTI4NDI5MSwiaWF0IjoxNTQ1MTk3ODkxfQ.gugOIY05bAHO7radjeIvkBYjhE2NQ-8MD64kfQy2zm0";
        public static string API_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
    }
}
