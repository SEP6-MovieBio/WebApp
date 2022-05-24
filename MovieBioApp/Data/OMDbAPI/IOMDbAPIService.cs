using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data.OMDbAPI
{
    public interface IOMDbAPIService
    {
        Task<OMDbAPIObj> GetOMDbAPIMovie(string movieName, decimal movieYear);

    }
}