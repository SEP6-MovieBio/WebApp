using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBioApp.Models.ClassesToReadJson;

namespace MovieBioApp.Data.PeopleService
{
    public interface IPeopleService
    {
        Task<List<Director>> GetTop20Directors();
        Task<List<Actor>> GetTop20Actors();
        Task<List<Actor>> SearchTop10Actors(string searchText);

        Task<List<Director>> SearchTop10Directors(string searchText);

    }
}