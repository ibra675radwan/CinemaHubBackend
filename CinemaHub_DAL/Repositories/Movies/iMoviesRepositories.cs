using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Movies
{
    public interface iMoviesRepositories : iGenericRepositories<Movie>
    {
        Movie GetMovieByName(string name);
        Task AddMovieAsync(Movie movie);


        Task<List<Movie>> GetMoviesByCinemaNameAsync(string cinemaName);
        Task<bool> DeleteMovieByNameAsync(string title);
        Task<List<Movie>> GetAllMoviesWithCinemaAsync();

        Task<List<Movie>> SearchMoviesByTitleAsync(string title);
        Task<List<Movie>> SuggestMoviesByTitlePatternAsync(string pattern);


    }
}
