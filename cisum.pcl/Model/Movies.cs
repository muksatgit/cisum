using System;
using System.Collections.Generic;
using cisum.pcl;

namespace cisum.Models
{
    public class Movies
    {
        public int resultCount { get; set; }
        public IList<Movie> results { get; set; }
    }
}
