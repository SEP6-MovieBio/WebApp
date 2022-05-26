using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models.ClassesToReadJson
{
    public class MovieJson
    {
        [JsonPropertyName("adult")]
        public bool adult { get; set; }
        [JsonPropertyName("backdrop_path")]
        public string backdrop_path { get; set; }
        [JsonPropertyName("genre_ids")]
        public List<int> genre_ids { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("media_type")]
        public string media_type { get; set; }
        [JsonPropertyName("original_language")]
        public string original_language { get; set; }
        [JsonPropertyName("original_title")]
        public string original_title { get; set; }
        [JsonPropertyName("overview")]
        public string overview { get; set; }
        [JsonPropertyName("poster_path")]
        public string poster_path { get; set; }
        [JsonPropertyName("release_date")]
        public string release_date { get; set; }
        [JsonPropertyName("title")]
        public string title { get; set; }
        [JsonPropertyName("video")]
        public bool video { get; set; }
        [JsonPropertyName("vote_average")]
        public double vote_average { get; set; }
        [JsonPropertyName("vote_count")]
        public int vote_count { get; set; }
        
        public MovieJson()
        {
            genre_ids = new List<int>();
        }
    }
}