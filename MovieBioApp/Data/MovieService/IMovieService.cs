using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBioApp.Models;

namespace MovieBioApp.Data.MovieService
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByRandChar(char randChar);
        Task<Movie> GetMovieById(int id);

        Task<List<Movie>> GetTop200Movies();
    }
}