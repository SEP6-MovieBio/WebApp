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
        Task PostMovieReview(MovieReview review);
        Task PatchMovieReview(string username, string reviewTextfield, float reviewRating, int movieID);
        Task<List<Movie>> SearchTop10Movies(string searchText);
        Task<double> GetMovieRatingByActorRating(int movieID);

        Task<Dictionary<string, double>> getMovieRatingByDecades();
    }
}