using System;
using System.Collections;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models
{
    public class TMDBAPIObj
    {
        [JsonPropertyName("adult")]
        public bool adult { get; set; }
        [JsonPropertyName("also_known_as")]
        public ArrayList alsoKnownAs { get; set; }
        [JsonPropertyName("biography")]
        public string biography { get; set; }
        [JsonPropertyName("birthday")]
        public string birthday { get; set; }
        [JsonPropertyName("deathday")]
        public string deathday { get; set; }
        [JsonPropertyName("gender")]
        public int gender { get; set; }
        [JsonPropertyName("homepage")]
        public string homepage { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("imdb_id")]
        public string imdbId { get; set; }
        [JsonPropertyName("known_for_department")]
        public string knownForDepartment { get; set; }
        [JsonPropertyName("known_for")]
        public string knownFor { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("place_of_birth")]
        public string placeOfBirth { get; set; }
        [JsonPropertyName("popularity")]
        public int popularity { get; set; }
        [JsonPropertyName("profile_path")]
        public string profilePath { get; set; }

        public string getPosterPath()
        {
            int start = knownFor.IndexOf("poster_path")+14;
            int end = knownFor.IndexOf("overview")-4;
            int length = end - start;
            string substring = knownFor.Substring(start, length);
            return substring;
        }
        
        
        
      
    }
}