using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using cisum.Model;

namespace cisum.Services
{
    public class BaseService
    {




        private HttpClient client;


        public BaseService()
        {
            client = new HttpClient();
        }




        // understand this in detail
        public async Task<List<Item>> fetchData()
        {
            List<Item> results = new List<Item>();
            var uri = new Uri(String.Format("https://itunes.apple.com/search?term=*&media=music", string.Empty));
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
