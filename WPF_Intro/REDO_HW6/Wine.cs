using System;
using System.Collections.Generic;
using System.Text;

namespace REDO_HW6
{
    public class Wine
    {
        public double id {get; set;}
        public string country {get; set;}
        public string description {get; set;}
        public string designation {get; set;}
        public double points {get; set;}
        public string price {get; set;}
        public string province {get; set;}
        public string region_1 {get; set;}
        public string region_2 { get; set; }
        public string taster_name { get; set; }
        public string taster_twitter_handle {get;set;}
        public string title {get;set;}
        public string variety {get;set;}
        public string winery {get;set;}

        public Wine()
        {
            id = 0;
            country = string.Empty;
            description = string.Empty;
            designation = string.Empty;
            points = 0;
            price = string.Empty;
            province = string.Empty;
            region_1 = string.Empty;
            region_2 = string.Empty;
            taster_name = string.Empty;
            taster_twitter_handle = string.Empty;
            title = string.Empty;
            variety = string.Empty;
            winery = string.Empty;
        }

        public override string ToString()
        {
            return $"{title}";
        }
    }
}
