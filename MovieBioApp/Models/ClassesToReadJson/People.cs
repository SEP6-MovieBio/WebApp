using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models.ClassesToReadJson
{
    public class People
    {
        [JsonPropertyName("adult")]
        public bool adult { get; set; }
        [JsonPropertyName("gender")]
        public int gender { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("known_for")]
        public List<MovieJson> known_for { get; set; }
        [JsonPropertyName("known_for_department")]
        public string known_for_department { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("popularity")]
        public double popularity { get; set; }
        [JsonPropertyName("profile_path")]
        public string profile_path { get; set; }
        
        
        
        
        public People()
        {
            known_for = new List<MovieJson>();
        }
    }
}