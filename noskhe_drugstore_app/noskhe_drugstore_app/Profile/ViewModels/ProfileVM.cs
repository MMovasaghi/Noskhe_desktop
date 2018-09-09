using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Profile.Models;
using noskhe_drugstore_app.Controller;
using noskhe_drugstore_app.Models.Minimals.Output;

namespace noskhe_drugstore_app.Profile.ViewModels
{
    public class ProfileVM
    {
        private ProfileModel _profileM;
        public ProfileModel profModel
        {
            get { return _profileM; }
            set { _profileM = value; }
        }
        public ProfileVM()
        {
            ReloadDataAsync(CurrentUser.UPI);
            profModel = new Models.ProfileModel();
        }
        public void Set_PharmacyInfo(Pharmacy p)
        {
            profModel.pharmacy = p;
        }
        public async void ReloadDataAsync(string UPI)
        {
            try
            {
                Repository repo = new Repository();
                var p = await repo.Get_Pharmacy_Info(UPI);
                profModel.pharmacy = new Pharmacy()
                {
                    Name = p.Name,
                    Phone = p.Phone,
                    Email = p.Email,
                    Credit = p.Credit,
                    Address = p.Address,
                    ManagerName = p.ManagerName,
                    ProfilePictureUrl = p.ProfilePictureUrl,
                };
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }
    }
}
