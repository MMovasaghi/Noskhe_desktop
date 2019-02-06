using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noskhe_drugstore_app.Star
{
    internal class StarViewModel
    {
        public Models.Minimals.Output.Score score { set; get; }

        private StarModel _starModel;
        public StarModel starModel
        {
            get { return _starModel; }
            set { _starModel = value; }
        }
        public StarViewModel()
        {
            GetScoreFromServer();
        }
        public async void GetScoreFromServer()
        {
            try
            {
                Controller.Repository repository = new Controller.Repository();
                Models.Minimals.Output.Score score = await repository.Get_Score();

                starModel = new StarModel
                {
                    Value = score.CustomerSatisfaction,
                };
            }
            catch (Exception)
            {
                starModel = new StarModel
                {
                    Value = 0,
                };                
            }
            
        }
    }
}
