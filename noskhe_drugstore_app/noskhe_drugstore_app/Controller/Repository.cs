using noskhe_drugstore_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using noskhe_drugstore_app.Models.CustomExceptions;

namespace noskhe_drugstore_app.Controller
{
    public class Repository
    {
        /*
            GET : get-database-status
            └──── Parameter(s): none
            └─────── Output(s): single 'Descriptive' object
            └──────── Error(s): DATABASE_FAILURE
            └───── Description: Checks whether the server can receive any data from database file or not.
            -----------------------------------------------------------------------------------------------------
            GET : get-server-status
            └──── Parameter(s): none
            └─────── Output(s): single 'Descriptive' object
            └──────── Error(s): none
            └───── Description: Checks whether the server communicates properly to it's clients.
            -----------------------------------------------------------------------------------------------------
            GET : get-details
            └──── Parameter(s): 'upi' string
            └─────── Output(s): single 'Pharmacy' object, single 'Descriptive' object
            └──────── Error(s): NO_PHARMACIES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Returns pharmacy details which can be used to show in profile.
            -----------------------------------------------------------------------------------------------------
            GET : get-orders
            └──── Parameter(s): 'upi' string
            └─────── Output(s): multiple 'Orders' objects, single 'Descriptive' object
            └──────── Error(s): BAD_START_TIME_FORMAT, BAD_END_TIME_FORMAT, START_TIME_IS_GREATER_THAN_END_TIME, NO_RESPONSES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Returns a list of orders which are linked to the pharmacy.
            -----------------------------------------------------------------------------------------------------
            GET : get-score
            └──── Parameter(s): 'upi' string
            └─────── Output(s): single 'Score' object, single 'Descriptive' object
            └──────── Error(s): NO_SCORES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Returns pharmacy score details.
            -----------------------------------------------------------------------------------------------------
            GET : get-settles
            └──── Parameter(s): 'upi' string
            └─────── Output(s): multiple 'Settle' objects, single 'Descriptive' object
            └──────── Error(s): NO_SETTLES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Gets a list of settles in which the pharmacy has submitted earlier.
            -----------------------------------------------------------------------------------------------------
            POST : set-settle
            └──── Parameter(s): single 'Settle' object
            └─────── Output(s): single 'Descriptive' object
            └──────── Error(s): NO_PHARMACIES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Sets a settle for the pharmacy which has requested.
            -----------------------------------------------------------------------------------------------------
            GET : get-top-five
            └──── Parameter(s): 'upi' string
            └─────── Output(s): multiple 'Score' objects, single 'Descriptive' object
            └──────── Error(s): DATABASE_FAILURE
            └───── Description: Returns the top five pharmacy based on their score given during their activity.
            -----------------------------------------------------------------------------------------------------
            POST : authenticate
            └──── Parameter(s): credential string[] (credential[0]: email, credential[1]: password)
            └─────── Output(s): single 'Descriptive' object
            └──────── Error(s): VERIFICATION_FAILED, DATABASE_FAILURE
            └───── Description: Checks whether the pharmacy client entered the right password or not.
                                Therefore, the application can redirect the client to pharmacy main page.
            -----------------------------------------------------------------------------------------------------
            PUT : change-status
            └──── Parameter(s): 'upi' string
            └─────── Output(s): single 'Descriptive' object
            └──────── Error(s): NO_PHARMACIES_MATCHED_THE_UPI, DATABASE_FAILURE
            └───── Description: Used to change the status of the pharmacy to ON/OFF. Basically, ON means
                                it will receive new orders from customers and OFF means the pharamcy service
                                is unavailabe.
            -----------------------------------------------------------------------------------------------------
            GET : get-weekly-number-of-orders
            └──── Parameter(s): 'upi' string
            └─────── Output(s): multiple 'float' values, single 'Descriptive' object
            └──────── Error(s): NO_PHARMACIES_MATCHED_THE_UPI, DATA_IS_NOT_AVAILABE, DATABASE_FAILURE
            └───── Description: Returns the daily number of orders in the recent week which a pharmacy has.
                                It is an array of 8 floats. The first 7 items are the number of orders of week days.
                                The last item is the average number of oreders of week.
            -----------------------------------------------------------------------------------------------------
            GET : get-weekly-packing-average-time            
            └──── Parameter(s): 'upi' string
            └─────── Output(s): multiple 'float' values, single 'Descriptive' object
            └──────── Error(s): NO_PHARMACIES_MATCHED_THE_UPI, DATA_IS_NOT_AVAILABE, DATABASE_FAILURE
            └───── Description: Returns packing average time during the recent week, which is an array
                                of 8 floats. The first 7 items are the time for the week days.
                                The last item is for total packing average time of week.
        */

        

        public HttpClient client = new HttpClient();
        public HttpResponseMessage responseMessage = new HttpResponseMessage();
        public Repository()
        {
            client.BaseAddress = new Uri(ServerURL.Main_Server_url);            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("desktop-api-key", "OWQ21KJED0ASDWQE0POCXM30239J");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }        
        public async Task<Descriptive> Get_DB_Status()
        {            
            responseMessage = await client.GetAsync("desktop-api/pharmacy/get-database-status");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Descriptive>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.Message == "DATABASE_FAILURE")
            {
                throw new DATABASE_FAILURE();
            }
            throw new NOT_RESPONDING();
        }
        public async Task<Descriptive> Get_Server_Status()
        {
            responseMessage = await client.GetAsync("desktop-api/pharmacy/get-server-status");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Descriptive>();
            
            throw new NOT_RESPONDING();
        }
        public async Task<Models.Minimals.Output.Pharmacy> Get_Pharmacy_Info(string UPI)
        {
            responseMessage = await client.GetAsync($"desktop-api/pharmacy/get-details?upi={UPI}");

            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<Models.Minimals.Output.Pharmacy>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.Message == "NO_PHARMACIES_MATCHED_THE_UPI")
            {
                throw new NO_PHARMACIES_MATCHED_THE_UPI();
            }
            else if (output.Message == "DATABASE_FAILURE")
            {
                throw new DATABASE_FAILURE();
            }
            throw new NOT_RESPONDING();
            
        }
        public async Task<bool> Check_Login(string[] login)
        {
            responseMessage = await client.PostAsJsonAsync($"desktop-api/pharmacy/authenticate", login);

            if (responseMessage.IsSuccessStatusCode)
                return true;

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.Message == "VERIFICATION_FAILED")
            {
                throw new VERIFICATION_FAILED();
            }
            else if (output.Message == "DATABASE_FAILURE")
            {
                throw new DATABASE_FAILURE();
            }
            throw new NOT_RESPONDING();

        }
        public async Task<string> GetUPI(string Email)
        {
            responseMessage = await client.GetAsync($"desktop-api/pharmacy/get-upi?email={Email}");
            if (responseMessage.IsSuccessStatusCode)
                return await responseMessage.Content.ReadAsAsync<string>();

            var output = await responseMessage.Content.ReadAsAsync<Descriptive>();
            if (output.Message == "NO_PHARMACIES_MATCHED_THE_EMAIL")
            {
                throw new NO_PHARMACIES_MATCHED_THE_UPI();
            }
            else if (output.Message == "DATABASE_FAILURE")
            {
                throw new DATABASE_FAILURE();
            }
            throw new NOT_RESPONDING();
        }

    }
}
