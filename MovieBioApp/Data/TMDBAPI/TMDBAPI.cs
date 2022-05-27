using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Models;
using MovieBioApp.Models.ClassesToReadJson;

namespace MovieBioApp.Data.TMDBAPI
{
    public class TMDBAPI : ITMDBAPI
    {
        private HttpClient client;

        private string uri = "https://api.themoviedb.org/3/search/person?api_key=df316df875c914165afedd12f7920c04&language=en-US&query=";
       // private string uri = "http://api.themoviedb.org/3/find/nm";
        //https://api.themoviedb.org/3/find/nm0000093?api_key=df316df875c914165afedd12f7920c04&language=en-US&external_source=imdb_id
        public TMDBAPI()
        {
            client = new HttpClient();
        }
        


        public async Task<Result> GetPersonById(string name)
        {
            /*string personID = "" + personId;
            char[] charArray = personID.ToCharArray();
            string zeroesBeforeId = "";
            switch (charArray.Length)
            {
                case 0:
                {
                    //do nothing
                }
                    break;
                case 1:
                {
                    zeroesBeforeId = "000000";
                }
                    break;
                case 2:
                {
                    zeroesBeforeId = "00000";
                }
                    break;
                case 3:
                {
                    zeroesBeforeId = "0000";
                }
                    break;
                case 4:
                {
                    zeroesBeforeId = "000";
                }
                    break;
                case 5:
                {
                    zeroesBeforeId = "00";
                }
                    break;
                case 6:
                {
                    zeroesBeforeId = "0";
                }
                    break;
                case 7:
                {
                    zeroesBeforeId = "";
                }
                    break;
                case 8:
                {
                    //error the api doesnt support id's over 7 digits
                    zeroesBeforeId = "0000";
                    personId = 329;
                }
                    break;
            }*/
            //?api_key=df316df875c914165afedd12f7920c04&language=en-US&external_source=imdb_id
            //https://api.themoviedb.org/3/search/person?api_key=df316df875c914165afedd12f7920c04&language=en-US&query=Jackie%20Chan
            Task<string> info = client.GetStringAsync(uri + $"{name}");
            //Task<string> info = client.GetStringAsync(uri + "?t=" + movieName + "&y="+movieYear + "&apikey=a4b57348");
            string message = await info;
            Result result = JsonSerializer.Deserialize<Result>(message);
            
            return result;

        }
    }
}