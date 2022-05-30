using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data
{
    public class UserInfoService
    {
        public async Task<UserInfo> GetUserInfoRest(string username)
        {
            string path = "https://moviebiodb.azurewebsites.net/userinfo?username=" + username;
            HttpClient client = new HttpClient();
            UserInfo userInfo = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                userInfo = JsonSerializer.Deserialize<UserInfo>(jsonString);
            }

            return userInfo;
        }

        public async Task<List<Movie>> GetFavoriteMovies(string username)
        {
            string path = "https://moviebiodb.azurewebsites.net/User/favoriteMovies?username=" + username;
            HttpClient client = new HttpClient();
            List<Movie> favorites = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                favorites = JsonSerializer.Deserialize<List<Movie>>(jsonString);
            }

            return favorites;
        }

        public async Task<bool> PostPasswordHash(string user)
        {
            string path = "https://moviebiodb.azurewebsites.net/User/postHash";
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(user,Encoding.UTF8, 
                "application/json");
            HttpResponseMessage response = await client.PostAsync(path,content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }
        public async Task<bool> Postbio(string userinfo)
        {
            string path = "https://moviebiodb.azurewebsites.net/User/postinfo";
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(userinfo,Encoding.UTF8, 
                "text/json");
            HttpResponseMessage response = await client.PostAsync(path,content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        public async Task<double> getNicenessRatio(string username)
        {
            string path = "https://moviebiodb.azurewebsites.net/User/Niceness?username=" + username;
            HttpClient client = new HttpClient();
            double rating = -1;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                rating = JsonSerializer.Deserialize<double>(jsonString);
            }

            return rating;
        }
    }
}