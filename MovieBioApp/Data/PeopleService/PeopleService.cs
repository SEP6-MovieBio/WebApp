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

        private HttpClient client;
        //private OMDbAPIService _omDbApiObj;


        public PeopleService()
        {
            client = new HttpClient();
        }
        
        public async Task<List<Director>> GetTop20Directors()
        {
            Task<string> info = client.GetStringAsync(uri + "top20Directors");
            string message = await info;
            List<Director> result = JsonSerializer.Deserialize<List<Director>>(message);
            Console.WriteLine(JsonSerializer.Serialize(result));
            
            return result;  
        }
    }
}