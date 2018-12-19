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

namespace noskhe_drugstore_app.Controller
{
    public class SignalR
    {
        private static HubConnection hubConnection = new HubConnectionBuilder()
                    .WithUrl(ServerURL.Hub_Server_url, options =>
                    {
                        options.AccessTokenProvider = () => Task.FromResult(ServerURL.AUTH_VALUE);
                    })
                    .Build();

        private static WindowCollection window = Application.Current.Windows;

        public static InterfaceNotifi nterfaceNotifi = null;
        public static AcceptUC acceptUC = new AcceptUC();
        public SignalR()
        {
            
        }
        //public static async Task ConnectingLogin(string user)
        //{
        //    System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
        //    hubConnection.On<List<NoskheAtFirst>>("HandleNotification", (message) =>
        //    {
        //        StringBuilder A = new StringBuilder();
        //        var ResultPicture =
        //            from i in message
        //            select i.Picture_Urls;
        //        var ResultNoskhe =
        //            from i in message
        //            select i.WithOutNoskhe_List;
        //        foreach (var item in ResultPicture)
        //        {
        //            foreach (var index in item)
        //            {
        //                A.Append(string.Format("P :   {0}\n", index));
        //            }
        //        }
        //        foreach (var item in ResultNoskhe)
        //        {
        //            foreach (var index in item)
        //            {
        //                A.Append(string.Format("N :   {0} : {1}\n", index.Number,index.Name));
        //            }
        //        }
        //        MessageBox.Show(A.ToString(),"Signal-R", MessageBoxButton.OK, MessageBoxImage.Information);
        //    });
        //    await hubConnection.StartAsync();
        //    await hubConnection.InvokeAsync("Initialize", user);
        //}
        //public static async Task SendMessage(sample user, string ToUser)
        //{
        //    await hubConnection.InvokeAsync("SendMessage", ToUser, user);
        //}
        public static async Task ConnectingLogin(string user)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            
            hubConnection.On<string>("HandleNotification", (message) =>
            {
                Application.Current.Dispatcher.Invoke(new Action(
                    delegate {
                        AcceptUC acceptUC = new AcceptUC();
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
                            TimerACVM.timerModel.sec = 60;
                            TimerACVM.StartTimer();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Initialize", user);

        }
        public static async Task SendMessage(string a, string ToUser)
        {
            await hubConnection.InvokeAsync("SendMessage", ToUser, a);
        }
        public static void mess()
        {
            //foreach (Window window in Application.Current.Windows)
            //{
            //    if (window.GetType() == typeof(MainWindow))
            //    {
            //        (window as MainWindow).StatusGrid.Visibility = Visibility.Hidden;
            //    }
            //}
            //MessageBox.Show("Pashmam","P",MessageBoxButton.OK,MessageBoxImage.Information);
            nterfaceNotifi.ShowNofitication();
        }

    }
    public class sample
    {
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
    }
    public class NoskheAtFirst
    {
        public List<string> Picture_Urls { set; get; }
        public List<WithOutNoskhe> WithOutNoskhe_List { set; get; }
    }
    public class WithOutNoskhe
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

}
