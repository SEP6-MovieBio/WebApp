using System.Text.Json.Serialization;

namespace MovieBioApp.Models
{
    public class MovieReview
    {
        [JsonPropertyName("reviewUsername")]
        public string ReviewUsername { get; set; }

        [JsonPropertyName("reviewDescription")]
        public string ReviewDescription { get; set; }

        [JsonPropertyName("reviewRating")]
        public double ReviewRating { get; set; }

        
        public string ToString()
        {
            // Converts the values into jsonFormat


            return "{"
                   + "\"reviewUsername\":" + "\"" + ReviewUsername + "\","
                   + "\"reviewDescription\":" + "\"" + ReviewDescription + "\","
                   + "\"reviewRating\":" + "\"" + ReviewRating + "\","
                   + "}";
        }
    }
}