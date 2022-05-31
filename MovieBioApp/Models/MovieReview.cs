using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models
{
    public class MovieReview
    {

        [JsonPropertyName("ReviewID")]
        public int ReviewID { get; set; }
        
        [JsonPropertyName("MovieID")]
        public int MovieID { get; set; }
        
        [JsonPropertyName("ReviewUsername")]
        public string ReviewUsername { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Description too long")]
        [JsonPropertyName("ReviewDescription")]
        public string ReviewDescription { get; set; }
        [Required]
        //[RegularExpression(@"^[0-10]+$", ErrorMessage = "No value selected")]
        [JsonPropertyName("ReviewRating")]
        public float ReviewRating { get; set; }

        
    }
}