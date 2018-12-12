using noskhe_drugstore_app.Noskhes.Doing.Models;
using System.Collections.ObjectModel;
using noskhe_drugstore_app.Persons;
using System.Windows.Threading;
using System;

namespace noskhe_drugstore_app.Noskhes.Doing.ViewModels
{
    public class DoingSicksMV
    {
        public void getparam(SickPerson sp)
        {
            timerModel = new TimerModel();
            
            doingSick = new DoingSick { sickPerson = sp };
        }
        public DoingSicksMV()
        {
            timerModel = new TimerModel();
            SickPerson sp = new SickPerson
            {
                FirstName = "رضا",
                LastName = "احمدی",
                Phone = "0912218934",
                BirthDate = "1/1/1 - 12:00AM"
            };
            doingSick = new DoingSick { sickPerson = sp };
        }

        private DoingSick _doingSick;
        public DoingSick doingSick
        {
            get { return _doingSick; }
            set { _doingSick = value; }
        }        

        public DispatcherTimer dt;

        private TimerModel _timerModel;
        public TimerModel timerModel
        {
            get { return _timerModel; }
            set { _timerModel = value; }
        }
        public void StartTimer()
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            timerModel.Sec++;
            if (timerModel.Sec == 60)
            {
                timerModel.Sec = 0;
                timerModel.Min++;
            }
            if (timerModel.Min == 25)
            {
                timerModel.Sec = 0;
                timerModel.Min = 0;
                dt.Stop();
            }
            timerModel.res = string.Format("{0:d2}:{1:d2}", timerModel.Min, timerModel.Sec);
        }
    }
}
