namespace MovieBioApp.Data
{
    public class Director
    {
        public int id { get; set; }
        public  string name { get; set; }
        public  double rating { get; set; }
        public  int age { get; set; }
        public  string TopDirectedMovie { get; set; }
        public string Picture { get; set; }
    
        public Director(int id = 0, string name = null, double rating = 0, int age = 0, string topDirectedMovie = null, string picture = null)
        {
            this.id = id;
            this.name = name;
            this.rating = rating;
            this.age = age;
            TopDirectedMovie = topDirectedMovie;
            Picture = picture;
        }
    }
}