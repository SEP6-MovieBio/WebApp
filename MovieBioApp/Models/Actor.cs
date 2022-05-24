namespace MovieBioApp.Data
{
    public class Actor
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  double Rating { get; set; }
        public  int Age { get; set; }
        public  string TopMovieStarredIn { get; set; }
        public string Picture { get; set; }
    
        public Actor(string firstName, string lastName, double rating, int age, string topMovieStarredIn, string picture)
        {
            FirstName = firstName;
            LastName = lastName;
            Rating = rating;
            Age = age;
            TopMovieStarredIn = topMovieStarredIn;
            Picture = picture;
        }
    }
}