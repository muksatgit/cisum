using System;
using cisum.pcl.Services;
using cisum.pcl.Model;
using GalaSoft.MvvmLight.Messaging;
using cisum.pcl.Utils;
using System.Collections.Generic;

namespace cisum.pcl.ViewModal
{
    public class HomeViewModal
    {
        BaseService bs;
        
        public HomeViewModal()
        {
            bs = new BaseService();

        }

        public async void loadData()
        {
            
            List<Result> MovieResults =  await bs.fetchData().ConfigureAwait(false);
            Messenger.Default.Send<MovieResults>(new MovieResults() { MovieResult = MovieResults});

        }
    }
}
