
using System.Threading.Tasks;
using MovieBioApp.Data;

namespace MovieBioApp.Controllers
{
    public class UserHandler
    {
        public string username { get; set; }
        public UserInfo UserInfo { get; set; }
        public UserInfoService Service { get; set; }

        public UserHandler(string username)
        {
            this.username = username;
            Service = new UserInfoService();
            UserInfo =  new UserInfo("test", "88888888", true, "test@tes.com", false, "This is a test account");//GetUserInfo(username).Result;
        }

        public async Task<UserInfo> GetUserInfo(string username)
        {
            return await Service.GetUserInfoRest(username);
        }
    }
}