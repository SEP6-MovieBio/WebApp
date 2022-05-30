﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data.UserService
{
    public class UserInfoService : IUserInfoService
    {
        
        
        //private string userInfoUri = "https://moviebiodb.azurewebsites.net/userinfo/";
        //private string userUri = "https://moviebiodb.azurewebsites.net/User/";

        //private string uri = "https://localhost:5003/MovieInfo/";
        private string userInfoUri = "https://localhost:5003/userinfo/";
        private string userUri = "https://localhost:5003/User/";
        
        private HttpClient client;
        //private OMDbAPIService _omDbApiObj;


        public UserInfoService()
        {
            client = new HttpClient();
        }
        
        public async Task<UserInfo> GetUserInfoRest(string username)
        {
            Task<string> path = client.GetStringAsync(userInfoUri +"?username=" + username);
            string message = await path;
            UserInfo result = JsonSerializer.Deserialize<UserInfo>(message);

            return result;
        }

        public async Task<List<Movie>> GetFavoriteMovies(string username)
        {
            string path = userUri + "favoriteMovies?username=" + username;
            List<Movie> favorites = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                favorites = JsonSerializer.Deserialize<List<Movie>>(jsonString);
            }

            return favorites;
        }

        public async Task<bool> PostPasswordHash(UserInfo user)
        {
            string path = userUri + "postHash";
            string userJson = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(userJson,Encoding.UTF8, 
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
            string path = userUri + "postinfo";
            HttpContent content = new StringContent(userinfo,Encoding.UTF8, 
                "text/json");
            HttpResponseMessage response = await client.PostAsync(path,content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        public async Task<User> GetValidatedUser(string username, string password)
        {
            Task<string> info = client.GetStringAsync(userUri + $"LoginCheck?username={username}&password={password}");
            string message = await info;
            User result = JsonSerializer.Deserialize<User>(message);

            return result;        
        }

        public async Task PostCreateUser(UserInfo userInfo)
        {
            string path = $"{userUri}postUser";
            
            string userJson = JsonSerializer.Serialize(userInfo);
            HttpContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(path, content);
            if (responseMessage.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Enter new information");
            }
        }
        
    }
}
