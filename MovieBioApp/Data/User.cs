namespace MovieBioApp.Data
{
    public class User
    {
        public string username { get; set; }
        public string hash { get; set; }

        public User(string username, string hash)
        {
            this.username = username;
            this.hash = hash;
        }
    }
}