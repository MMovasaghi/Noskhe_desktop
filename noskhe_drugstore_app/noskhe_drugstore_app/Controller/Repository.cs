using noskhe_drugstore_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Models.CustomExceptions;
using noskhe_drugstore_app.Login;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using noskhe_drugstore_app.Models.GetDataHandler;

namespace noskhe_drugstore_app.Controller
{
    public class Repository
    {
        public HttpClient client = new HttpClient();
        public HttpResponseMessage responseMessage = new HttpResponseMessage();
        static bool LoginSignalR = true;
        public Repository()
        {
            client.BaseAddress = new Uri(ConnectionUrls.Main_Server_url);            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add(ConnectionUrls.API_KEY_TYPE, ConnectionUrls.API_KEY_VALUE);
            client.DefaultRequestHeaders.Add(ConnectionUrls.AUTH_TYPE , ConnectionUrls.AUTH_VALUE);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }        
        public async Task<Descriptive> Get_DB_Status()
        {            
            responseMessage = await client.GetAsync( ConnectionUrls.ROUTE + "/db-state");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Descriptive>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
        public async Task<Descriptive> Get_Server_Status()
        {
            responseMessage = await client.GetAsync( ConnectionUrls.ROUTE + "/server-state");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Descriptive>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
        public async Task<Models.Minimals.Output.Pharmacy> Get_Pharmacy_Info()
        {
            responseMessage = await client.GetAsync( ConnectionUrls.ROUTE + "/profile");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Models.Minimals.Output.Pharmacy>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();

        }
        public async Task<bool> Check_Login(string[] login)
        {
            responseMessage = await client.PostAsJsonAsync(ConnectionUrls.ROUTE + "/Login", login);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                LoginToken response = await responseMessage.Content.ReadAsAsync<LoginToken>();
                Token.Value = response.token;
                ConnectionUrls.AUTH_VALUE = "Bearer " + Token.Value;
                AppData appData = new AppData();
                bool res = appData.SaveConnectionUrls(login[0], login[1]);

                if (LoginSignalR)
                {
                    await SignalR.ConnectingLogin();
                    LoginSignalR = false;
                }                 

                return res;
            }

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC4")
            {
                throw new VERIFICATION_FAILED();
            }
            else if (output.error == "PEC2")
            {
                throw new DATABASE_FAILURE();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();

        }
        public async Task<Models.Minimals.Output.Score> Get_Score()
        {
            responseMessage = await client.GetAsync(ConnectionUrls.ROUTE + "/score");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Models.Minimals.Output.Score>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
        public async Task<List<Models.Minimals.Output.Order>> Get_AllOrders()
        {
            responseMessage = await client.GetAsync(ConnectionUrls.ROUTE + "/orders");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<List<Models.Minimals.Output.Order>>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
        public async Task<ResonTemplate> AcceptanceOfNoskhe(int shoppingCartId, bool accepted, Models.PharmacyCancellationReason reason)
        {
            string result = "shoppingCartId=" + shoppingCartId + "&accepted=" + accepted + "&reason=" + reason;

            responseMessage = await client.GetAsync(ConnectionUrls.ROUTE + "/service-response?"+ result);

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<ResonTemplate>();

            var output = await responseMessage.Content.ReadAsAsync<ResonTemplate>();
            if (output.Error == "PEC0")
            {
                throw new TOKEN_EXPIRATION();
            }
            else if (output.Error == "PEC1")
            {
                throw new API_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
    }
}
