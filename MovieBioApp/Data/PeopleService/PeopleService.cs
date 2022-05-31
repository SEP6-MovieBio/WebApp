using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Models;
using MovieBioApp.Models.ClassesToReadJson;

namespace MovieBioApp.Data.PeopleService
{
    public class PeopleService : IPeopleService
    {
        private string uri = "https://moviebiodb.azurewebsites.net/Director/";
        private string uriForActors = "https://moviebiodb.azurewebsites.net/Actor/";

        private HttpClient client;
        //private OMDbAPIService _omDbApiObj;
        public List<Actor> actors { get; set; }
        public List<Director> directors { get; set; }


        public PeopleService()
        {
            client = new HttpClient();
            actors = new List<Actor>();
            directors = new List<Director>();
        }
        
        public async Task<List<Director>> GetTop20Directors()
        {
            Task<string> info = client.GetStringAsync(uri + "top20Directors");
            string message = await info;
            List<Director> result = JsonSerializer.Deserialize<List<Director>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            
            return result;  
        }
        
        public async Task<List<Director>> SearchTop10Directors(string searchText)
        {
            Task<string> info = client.GetStringAsync(uri + $"searchTop10Directors?searchText={searchText}");
            string message = await info;
            List<Director> result = JsonSerializer.Deserialize<List<Director>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            return result;

        }
        

        public async Task<List<Actor>> GetTop20Actors()
        {
            Task<string> info = client.GetStringAsync(uriForActors + "top20Actors");
            string message = await info;
            List<Actor> result = JsonSerializer.Deserialize<List<Actor>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            
            return result;  
        }
        
        public async Task<List<Actor>> SearchTop10Actors(string searchText)
        {
            Task<string> info = client.GetStringAsync(uriForActors + $"searchTop10Actors?searchText={searchText}");
            string message = await info;
            List<Actor> result = JsonSerializer.Deserialize<List<Actor>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            return result;
        }

        public async Task<Director> GetDirectorById(int id)
        {
            Task<string> info = client.GetStringAsync(uri + $"getDirector?id={id}");
            string message = await info;
            Director result = JsonSerializer.Deserialize<Director>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            return result;
        }
        
        public async Task<Actor> GetActorById(int id)
        {
            Task<string> info = client.GetStringAsync(uriForActors + $"getActor?id={id}");
            string message = await info;
            Actor result = JsonSerializer.Deserialize<Actor>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            return result;
        }
    }
}