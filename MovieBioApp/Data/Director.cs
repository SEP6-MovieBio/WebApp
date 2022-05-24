namespace MovieBioApp.Data
{
    public class Director
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  double Rating { get; set; }
        public  int Age { get; set; }
        public  string TopDirectedMovie { get; set; }
        public string Picture { get; set; }
    
        public Director(string firstName, string lastName, double rating, int age, string topDirectedMovie, string picture)
        {
            FirstName = firstName;
            LastName = lastName;
            Rating = rating;
            Age = age;
            TopDirectedMovie = topDirectedMovie;
            Picture = picture;
        }
    }
}