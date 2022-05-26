namespace MovieBioApp.Models
{
    public class User
    {
        public string username { get; set; }
        public string hash { get; set; }

        public int securityLevel { get; set; }
        
        
        public User(string username, string hash, int securityLevel)
        {
            this.username = username;
            this.hash = hash;
            this.securityLevel = securityLevel;
        }
        public User()
        {
            username = "No username";
            hash = "No password";
        } 
        
        
    }
}