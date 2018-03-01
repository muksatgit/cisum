using System;
using System.Collections.Generic;

namespace cisum.pcl.Models
{
    public class Movies
    {
        public int resultCount { get; set; }
        public IList<Movie> results { get; set; }
    }
}
