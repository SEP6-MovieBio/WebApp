﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data.UserService
{
    public interface IUserInfoService
    {
        Task<UserInfo> GetUserInfoRest(string username);
        Task<List<Movie>> GetFavoriteMovies(string username);
        Task<bool> PostPasswordHash(string user);
        Task<bool> Postbio(string userinfo);

        //Testing
        Task<User> GetValidatedUser(string username, string password);
        Task<bool> PostPasswordHashString(string username, string password);
        Task PostCreateUser(UserInfo userInfo);
    }
}