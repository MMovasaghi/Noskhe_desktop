using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Finance.RepoOfCashOut.Models;

namespace noskhe_drugstore_app.Finance.RepoOfCashOut.ViewModels
{
    public class CashOutVM
    {
        private List<CashOutModel> _cashout;

        public List<CashOutModel> cashout
        {
            get { return _cashout; }
            set { _cashout = value; }
        }
    }
}
