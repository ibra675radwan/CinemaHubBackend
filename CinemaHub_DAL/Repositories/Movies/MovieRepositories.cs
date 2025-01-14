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


        public async Task<List<Movie>> GetMoviesByCinemaNameAsync(string cinemaName)
        {
            return await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Genre)
                .Where(m => m.Cinema != null && m.Cinema.Name == cinemaName)
                .ToListAsync();
        }

        public async Task<bool> DeleteMovieByNameAsync(string title)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Title == title);
            if (movie == null)
            {
                return false; // Cinema not found
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true; // Cinema deleted
        }

        public async Task<List<Movie>> GetAllMoviesWithCinemaAsync()
        {
            return await _context.Movies
                .Include(m => m.Cinema) // Include Cinema relationship
                .Include(m => m.Genre)  // Include Genre relationship
                .ToListAsync();
        }

        public async Task<List<Movie>> SuggestMoviesByFirstLetterAsync(char firstLetter)
        {
            return await _context.Movies
                .Where(m => m.Title.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }


    }
}
