using System.Threading.Tasks;
using MovieBioApp.Models;
using MovieBioApp.Models.ClassesToReadJson;

namespace MovieBioApp.Data.TMDBAPI
{
    public interface ITMDBAPI
    {
        Task<Result> GetPersonById(string name);
    }
}