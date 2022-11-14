using Newtonsoft.Json;
using OMB.App.Models;
using OMB.App.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OMB.App
{
    public static class Data
    {
        public static bool AddOwner()
        {
            var client = new HttpClient();
            MobileRequest request = new MobileRequest();
            request.id = 43;
            request.requestType = 101;
            
            string url = $"{OMB.App.DAL.Resources.BaseURL}/Factory";
                       
            StringContent content  =new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            if (response != null)
            {
                return true;
            }
            return false;
        }
    }
}
