using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Noskhes.Dones.Models;
using noskhe_drugstore_app.Persons;
using System.Collections.ObjectModel;

namespace noskhe_drugstore_app.Noskhes.Dones.ViewModels
{
    class SickMV
    {
        private ObservableCollection<SickDetailModel> _sickDetailModel;

        public ObservableCollection<SickDetailModel> sickDetailModel
        {
            get { return _sickDetailModel; }
            set { _sickDetailModel = value; }
        }

        public SickMV()
        {
            SickPerson sp = new SickPerson
            {
                FirstName = "علی",
                LastName = "رضایی",
                Phone = "0912218934",
                BirthDate = "1/1/1 - 12:00AM"
            };

            sickDetailModel = new ObservableCollection<SickDetailModel>
            {
                new SickDetailModel{sickPerson = sp},
            };



        }
    }
}
