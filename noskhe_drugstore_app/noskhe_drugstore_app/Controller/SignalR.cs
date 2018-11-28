using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;
using noskhe_drugstore_app.Models;
using System.Diagnostics;

namespace noskhe_drugstore_app.Controller
{
    public class SignalR
    {
        private static HubConnection hubConnection = new HubConnectionBuilder()
                    .WithUrl(ServerURL.Hub_Server_url) // ===> SignalRTest1
                    .Build();

        public SignalR()
        {
            
        }       

        public static async Task ConnectingLogin(string user)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            
            hubConnection.On<sample>("HandleNotification", (message) =>
            {
                //Debug.WriteLine(".....>>>>> " + message);
                MessageBox.Show(string.Format("Url0 : {0}\nUrl2 : {1}\n", message.Url1, message.Url2),
                    "Signal-R", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Initialize", user);

        }
        public static async Task SendMessage(sample user, string ToUser)
        {
            await hubConnection.InvokeAsync("SendMessage", ToUser, user);
        }


    }
    public class sample
    {
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
    }

    
}
