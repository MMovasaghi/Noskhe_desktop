using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Controller
{
    public static class ServerURL
    {
        public static string Main_Server_url = "http://192.168.1.59:5000"; 
        public static string Hub_Server_url = Main_Server_url + "/NotificationHub/";
        public static string ROUTE = "/desktop-api/pharmacy";
        public static string API_KEY_TYPE = "desktop-api-key";
        public static string API_KEY_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
        public static string AUTH_TYPE = "Authorization";
        public static string AUTH_VALUE = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1NDU4MjYxNTksImV4cCI6MTU0NTkxMjU1OSwiaWF0IjoxNTQ1ODI2MTU5fQ.N8m_tddoOugx7nTrh6mqcYvdM3xxotA5mp0L26vWf84";
        public static string API_VALUE = "k3bKN^u9o(sW;qH8zKXp^:.=P[}`gQ'V!wJ*8CK_da%?KB~w!?V{[YxnaY*6!rs";
    }
}
