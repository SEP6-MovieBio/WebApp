

namespace MovieBioApp.Data
{
    public class Movie
    {
        public string Title { get; set; }
        public  string Genre { get; set; }
        public  double Rating { get; set; }
        public  string Director { get; set; }
        public  string StarActor { get; set; }
        public string Picture { get; set; }
    
        public Movie(string title, string genre, double rating, string director, string starActor, string picture)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
            Director = director;
            StarActor = starActor;
            Picture = picture;
        }
        
    }
    
    
}