using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieBioApp.Authentication;
using MovieBioApp.Data;
using MovieBioApp.Data.MovieService;
using MovieBioApp.Data.OMDbAPI;
using MovieBioApp.Data.PeopleService;
using MovieBioApp.Data.UserService;
using MovieBioApp.Models;
using UserInfoService = MovieBioApp.Data.UserService.UserInfoService;

namespace MovieBioApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IOMDbAPIService, OMDbAPIService>();
            services.AddSingleton<IPeopleService, PeopleService>();

            services.AddSingleton<IUserInfoService, UserInfoService>();

            services.AddScoped<AuthenticationStateProvider, CustomAuthentication>();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("LoggedInUser", a =>
                    a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "1"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}