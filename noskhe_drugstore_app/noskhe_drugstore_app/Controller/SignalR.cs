﻿using System;
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

        public static HubConnection hubConnection = new HubConnectionBuilder()
                    .WithUrl(ConnectionUrls.Hub_Server_url,option => { option.Headers.Add("Authorization", Token.Value); })
                    .Build();

        private static WindowCollection window = Application.Current.Windows;

        public static AcceptUC acceptUC = new AcceptUC();

        private static string MY_NAME { get; set; }

        public static async Task ConnectingLogin()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

            hubConnection.On<NoskheForFirstNotificationOnDesktop>("PharmacyReception", (message) =>
            {
                MessageNotification(message);
            });
            //call server signal r start
            await hubConnection.StartAsync();
        }
        public static async Task ConnectingLogout()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            
            await hubConnection.StopAsync();
        }
        public async static void MessageNotification(NoskheForFirstNotificationOnDesktop message)
        {
            //Sending in Application notification ----------------------------------------------------
            try
            {
                Application.Current.Dispatcher.Invoke(new Action(
                    delegate
                    {
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
                            TimerACVM.timerModel.sec = 120;
                            TimerACVM.StartTimer();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
            catch (Exception)
            {
                //send to server that the Process was killed & Refuse the Prescription
                Repository repository = new Repository();
                await repository.AcceptanceOfNoskhe(message.Notation.ShoppingCartId, false, 0);
            }            
            //--------------------------------------------------------------------------------------
        }
        public class Descriptiveg
        {
            public bool Success { get; set; }
            public string Error { get; set; }
        }
    }

}
