using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Data.OMDbAPI;
using MovieBioApp.Models;

namespace MovieBioApp.Data.MovieService
{
    public class MovieService : IMovieService
    {
        private string uri = "https://moviebiodb.azurewebsites.net/MovieInfo/";
        //private string uri = "https://localhost:5002/MovieInfo/";

        private HttpClient client;
        //private OMDbAPIService _omDbApiObj;


        public MovieService()
        {
            client = new HttpClient();
        }
        
        //GET Movie by random character
        public async Task<Movie> GetMovieByRandChar(char randChar)
        {
            Task<string> info = client.GetStringAsync(uri + $"RandomChar?randChar={randChar}");
            string message = await info;
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            return result;
        }

        //GET Movie by ID
        public async Task<Movie> GetMovieById(int id)
        {
            Task<string> info = client.GetStringAsync(uri + $"MovieID?id={id}");
            string message = await info;
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            return result;        
        }
        
        //Get top200 movies
        public async Task<List<Movie>> GetTop200Movies()
        {
            Task<string> info = client.GetStringAsync(uri + "top200Movies");
            string message = await info;
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            
            return result;  
        }
        
    }
}