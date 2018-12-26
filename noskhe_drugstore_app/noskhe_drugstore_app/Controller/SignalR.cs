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
using noskhe_drugstore_app.AcceptPH;
using noskhe_drugstore_app.AcceptPH.ViewModels;
using noskhe_drugstore_app.Models.Minimals.Output;

namespace noskhe_drugstore_app.Controller
{
    public class SignalR
    {
        private static HubConnection hubConnection = new HubConnectionBuilder()
                    .WithUrl(ServerURL.Hub_Server_url)
                    .Build();

        private static WindowCollection window = Application.Current.Windows;

        public static AcceptUC acceptUC = new AcceptUC();

        private static string MY_NAME { get; set; }

        public static async Task ConnectingLogin(string user)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            
            hubConnection.On<NoskheForFirstNotificationOnDesktop>("HandleNotification", (message) =>
            {
                MessageNotification(message);
            });
            hubConnection.On<int,string>("RecieveStatus", (status,MyName) =>
            {
                if(status == 1)
                {
                    MY_NAME = MyName;
                }
                else
                {
                    MY_NAME = "NULL";
                }                
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Initialize", 1 , ServerURL.AUTH_VALUE);

        }
        public static async Task SendMessage(string a, string ToUser)
        {
            await hubConnection.InvokeAsync("SendMessage", ToUser, a);
        }
        public static void MessageNotification(NoskheForFirstNotificationOnDesktop message)
        {
            Application.Current.Dispatcher.Invoke(new Action(
                    delegate {
                        AcceptUC acceptUC = new AcceptUC();
                        acceptUC.GetObjectOfNoskhe(message);
                        
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                (window as MainWindow).AcceptForm.Visibility = Visibility.Visible;
                                (window as MainWindow).XAcceptForm.Children.Add(acceptUC);
                            }
                        }
                        try
                        {
                            //Timer of Accept Page start
                            TimerACVM.timerModel.sec = 90;
                            TimerACVM.StartTimer();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
        }

    }

}
