using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data.OMDbAPI
{
    public class OMDbAPIService : IOMDbAPIService
    {
        
        private HttpClient client;
        private string uri = "http://www.omdbapi.com/";

        public OMDbAPIService()
        {
            client = new HttpClient();
        }
        


        public async Task<OMDbAPIObj> GetOMDbAPIMovie(string movieName, decimal movieYear)
        {
            //Task<string> info = client.GetStringAsync(uri + $"?t={movieName}&y={movieYear}&apikey=a4b57348");
            Task<string> info = client.GetStringAsync(uri + "?t=" + movieName + "&y="+movieYear + "&apikey=a4b57348");

            string message = await info;
            OMDbAPIObj result = JsonSerializer.Deserialize<OMDbAPIObj>(message);
            
            return result;

        }


    }
}