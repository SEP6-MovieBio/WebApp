using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models
{
    public class OMDbAPIObj
    {
        [JsonPropertyName("Title")]
        public string title { get; set; }
        
        [JsonPropertyName("Year")]
        public string year { get; set; }

        [JsonPropertyName("Rated")] 
        //Like R rated or something
        public string rated { get; set; }

        [JsonPropertyName("Released")]
        public string released { get; set; }

        [JsonPropertyName("Runtime")]
        public string duration { get; set; }

        [JsonPropertyName("Genre")]
        public string genre { get; set; }

        [JsonPropertyName("Director")]
        public string directors { get; set; }

        [JsonPropertyName("Writer")]
        public string writers { get; set; }

        [JsonPropertyName("Actors")]
        public string actors { get; set; }

        [JsonPropertyName("Plot")]  
        public string description { get; set; }

        [JsonPropertyName("Language")]
        public string language { get; set; }

        [JsonPropertyName("Country")]
        public string country { get; set; }

        [JsonPropertyName("Awards")]
        public string awards { get; set; }

        [JsonPropertyName("Poster")]
        public string image { get; set; }

        /*
        [JsonPropertyName("Ratings")]
        public string ratings { get; set; }*/
        
        [JsonPropertyName("Value")]
        public string ratingValue { get; set; }
        
        [JsonPropertyName("Metascore")]
        public string metascore { get; set; }

        [JsonPropertyName("imdbRating")]
        public string imdbRating { get; set; }

        [JsonPropertyName("imdbVotes")]
        public string votes { get; set; }
        
        [JsonPropertyName("imdbID")]
        public string imdbId { get; set; }

        [JsonPropertyName("Type")]
        public string type { get; set; }

        [JsonPropertyName("DVD")]
        public string dvd { get; set; }

        [JsonPropertyName("BoxOffice")]
        public string boxOffice { get; set; }

        [JsonPropertyName("Production")]
        public string production { get; set; }

        [JsonPropertyName("Website")]
        public string website { get; set; }

        [JsonPropertyName("Response")]
        public string response { get; set; }


        public string ToString()
        {
            // Converts the values into jsonFormat

            return "{"
                   + "\"Title\":" + "\"" + title + "\","
                   + "\"Year\":" + "\"" + year + "\","
                   + "\"Rated\":" + "\"" + rated + "\","
                   + "\"Released\":" + "\"" + released + "\","
                   + "\"Runtime\":" + "\"" + duration + "\","
                   + "\"Genre\":" + "\"" + genre + "\","
                   + "\"Director\":" + "\"" + directors + "\","
                   + "\"Writer\":" + "\"" + writers + "\","
                   + "\"Actors\":" + "\"" + actors + "\","
                   + "\"Plot\":" + description + ","
                   + "\"Language\":" + language + ","
                   + "\"Country\":" + "\"" + country + "\"" +","
                   + "\"Awards\":" + awards
                   + "\"Poster\":" + image
                   //+ "\"Ratings\":" + ratings
                   + "\"Value\":" + ratingValue
                   + "\"Metascore\":" + metascore
                   + "\"imdbRating\":" + imdbRating
                   + "\"imdbVotes\":" + votes
                   + "\"imdbID\":" + imdbId
                   + "\"Type\":" + type
                   + "\"DVD\":" + dvd
                   + "\"BoxOffice\":" + boxOffice
                   + "\"Production\":" + production
                   + "\"Website\":" + website
                   + "\"Response\":" + response
                   + "}";
        }
        

    }
}