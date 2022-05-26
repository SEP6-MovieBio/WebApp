using System.Text.Json.Serialization;

namespace MovieBioApp.Data
{
    public class Actor
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public  string Name { get; set; }
        [JsonPropertyName("rating")]
        public  double Rating { get; set; }
        [JsonPropertyName("age")]
        public  int Age { get; set; }
        [JsonPropertyName("knownFor")]
        public  string KnownFor { get; set; }
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
    
        public Actor(int id = 0, string name = null, double rating = 0, int age = 0, string knownFor = null, string picture = null)
        {
            this.id = id;
            Name = name;
            Rating = rating;
            Age = age;
            KnownFor = knownFor;
            Picture = picture;
        }
    }
}