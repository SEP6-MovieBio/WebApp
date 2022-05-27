using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MovieBioApp.Controllers;
using MovieBioApp.Data;
using MovieBioApp.Data.UserService;
using MovieBioApp.Models;

namespace MovieBioApp.Authentication
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserInfoService _userService;

        public static User CachedUser;

        public CustomAuthentication(IJSRuntime jsRuntime, IUserInfoService userService)
        {
            this._jsRuntime = jsRuntime;
            this._userService = userService;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (CachedUser == null)
            {
                string userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    CachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(CachedUser);
                }
            }
            else
            {
                identity = SetupClaimsForUser(CachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string username, string password) {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            
            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                User user = await _userService.GetValidatedUser(username, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                Console.WriteLine($"User logged is: {user.Username} and {user.Password} and {user.SecurityLevel}");
                CachedUser = user;

            } catch (Exception e) {
                throw e;
            }
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        
        private ClaimsIdentity SetupClaimsForUser(User user) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim("SecurityLevel", user.SecurityLevel.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
        public void Logout() {
            CachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }


    }
}