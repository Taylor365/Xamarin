using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetflixRoulette.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("release_date")]
        public string Year { get; set; }

        private string poster;

        [JsonProperty("poster_path")]
        public string Poster {
            get
            {
                return poster;
            }
            set
            {
                poster = "https://image.tmdb.org/t/p/w500/" + value;
            }
        }
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("original_title")]
        public string Ot { get; set; }
        [JsonProperty("original_language")]
        public string Ol { get; set; }
        [JsonProperty("backdrop_path")]
        public string Bp { get; set; }
        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }
        [JsonProperty("vote_count")]
        public int Vote { get; set; }
        [JsonProperty("video")]
        public bool Video { get; set; }
        [JsonProperty("vote_average")]
        public decimal Vote_Avg { get; set; }
    }
}
