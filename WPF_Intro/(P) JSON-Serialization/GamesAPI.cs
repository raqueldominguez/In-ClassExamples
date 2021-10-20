using System;
using System.Collections.Generic;
using System.Text;

namespace _P__JSON_Serialization
{
    public class GamesAPI
    {
        public string name {get;set;}
        public string platform {get;set;}
        public string release_date {get;set;}
        public string summary {get;set;}
        public int meta_score { get; set; }
        public string user_review { get; set; }

        public GamesAPI()
        {
            name = string.Empty;
            platform = string.Empty;
            release_date = string.Empty;
            summary = string.Empty;
            meta_score = 0;
            user_review = string.Empty;
        }

/*        public GamesAPI(string Name, string Platform, string Release_Date, string Summary, int Meta_Score, string USer_Review)
        {
            name = Name;
            platform = Platform;
            release_date = Release_Date;
            summary = Summary;
            meta_score = Meta_Score;
            user_review = USer_Review;
        }*/

        public override string ToString()
        {
            return $"{name}"; 
        }

    }
}
