using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBioApp.Models.ClassesToReadJson;

namespace MovieBioApp.Data.PeopleService
{
    public interface IPeopleService
    {
        Task<List<Director>> GetTop20Directors();
    }
}