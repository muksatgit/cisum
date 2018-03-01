using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using cisum.pcl.Models;
using cisum.pcl.Model;

namespace cisum.pcl.Services
{
    public class BaseService
    {




        private HttpClient client;


        public BaseService()
        {
            client = new HttpClient();
        }




        // understand this in detail
        public async Task<List<Result>> fetchData()
        {
            List<Result> results = new List<Result>();
            var uri = new Uri(String.Format("https://itunes.apple.com/search?term=*", string.Empty));
            var response = await  client.GetAsync(uri);

            if(response.IsSuccessStatusCode)
            {

               var content = await response.Content.ReadAsStringAsync();
               var items = JsonConvert.DeserializeObject<RootObject>(content);

                results = items.results;

            }

            return results;
        }



    }
}
