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

        public static async Task ConnectingLogin(SignalR_Sample user)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

            hubConnection.On<SignalR_Sample>("HandleNotification", (message) =>
            {
                MessageBoxResult mbox1 = MessageBox.Show(string.Format("Message ID : {0}\n From : {1}", message.ID,message.Name), "Signal-R", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Initialize", user.Name);

        }
        public static async Task SendMessage(SignalR_Sample user, string ToUser)
        {
            await hubConnection.InvokeAsync("SendMessage", user.Name , user);
        }


    }
    
}
