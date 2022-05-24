using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Data.OMDbAPI;
using MovieBioApp.Models;

namespace MovieBioApp.Data.MovieService
{
    public class MovieService : IMovieService
    {
        //private string uri = "https://moviebiodb.azurewebsites.net/MovieInfo/";
        private string uri = "https://localhost:5002/MovieInfo/";

        private HttpClient client;
        private OMDbAPIService _omDbApiObj;


        public MovieService()
        {
            client = new HttpClient();
        }
        
        //GET Movie by ID
        public async Task<Movie> GetMovieById(int movieId)
        {
            Task<string> info = client.GetStringAsync(uri + $"movieId?id={movieId}");
            string message = await info;
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            return result;
        }
        
    }
}