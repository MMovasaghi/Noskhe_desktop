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

        private static HubConnection hubConnection = new HubConnectionBuilder()
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
            hubConnection.On<int,string>("RecieveStatus", (status,MyName) =>
            {
                if(status == 1 && MyName != "")
                {
                    MY_NAME = MyName;
                }
                else
                {
                    MY_NAME = "NULL";
                }                
            });
            //call server signal r start
            await hubConnection.StartAsync();
        }
        public static async Task SendMessage(string a, string ToUser)
        {
            await hubConnection.InvokeAsync("P_PharmacyReception", 1, a);
        }
        public static void MessageNotification(NoskheForFirstNotificationOnDesktop message)
        {
            //Sending in Application notification ----------------------------------------------------
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
                            TimerACVM.timerModel.sec = 90;
                            TimerACVM.StartTimer();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            //--------------------------------------------------------------------------------------
        }
        public class Descriptiveg
        {
            public bool Success { get; set; }
            public string Error { get; set; }
        }
    }

}
