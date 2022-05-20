using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieBioApp.Data
{
    public class UserInfoService
    {
        public async Task<UserInfo> GetUserInfoRest(string username)
        {
            string path = "https://moviebiodb.azurewebsites.net/userinfo?username=" + username;
            HttpClient client = new HttpClient();
            UserInfo userInfo = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                userInfo = JsonSerializer.Deserialize<UserInfo>(jsonString);
            }

            return userInfo;
        }
    }
}