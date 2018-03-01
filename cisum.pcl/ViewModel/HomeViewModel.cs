using System;
using cisum.Services;
using cisum.Model;
using GalaSoft.MvvmLight.Messaging;
using cisum.Utils;
using System.Collections.Generic;

namespace cisum.ViewModel
{
    public class HomeViewModel
    {
        BaseService bs;
        
        public HomeViewModel()
        {
            bs = new BaseService();

        }

        public async void loadData()
        {
            
            List<Item> APIResults = await bs.fetchData().ConfigureAwait(false);
            Messenger.Default.Send<APIResults>(new APIResults() { APIResult = APIResults });


        }
    }
}
