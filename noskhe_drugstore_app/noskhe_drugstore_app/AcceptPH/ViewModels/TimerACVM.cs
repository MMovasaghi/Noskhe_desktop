using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.AcceptPH.Models;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace noskhe_drugstore_app.AcceptPH.ViewModels
{
    internal class TimerACVM
    {
        public static DispatcherTimer dt;

        private static TimerACModel _timerModel;
        public static TimerACModel timerModel
        {
            get { return _timerModel; }
            set { _timerModel = value; }
        }
        public TimerACVM()
        {
            timerModel = new TimerACModel();
            //timerModel.sec = 60;
            timerModel.TimerAlert = Brushes.White;
        }
        public static void StartTimer()
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }
        private static void Dt_Tick(object sender, EventArgs e)
        {
            timerModel.sec--;
            if (timerModel.sec <= 15)
            {
                timerModel.TimerAlert = Brushes.Red;
            }
            if (timerModel.sec == 0)
            {
                dt.Stop();
                timerModel.TimerAlert = Brushes.White;
            }

        }
    }
}
