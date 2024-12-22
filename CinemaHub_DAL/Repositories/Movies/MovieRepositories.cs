using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Movies
{
    public class MovieRepositories : GenericRepositories<Movie>, iMoviesRepositories
    {
        private readonly CinemaHubContext _context;
        public MovieRepositories(CinemaHubContext cinemaHubContext) : base(cinemaHubContext)
        {

           _context = cinemaHubContext;

        }
        public Movie GetMovieByName(string name) 
        {
        var result = _dbSet.Where(x=>x.Title == name).FirstOrDefault();
            return result;
        
        
        }
        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie); // Add the movie entity to the context
            await _context.SaveChangesAsync(); // Save changes to the database
        }
    }
}
