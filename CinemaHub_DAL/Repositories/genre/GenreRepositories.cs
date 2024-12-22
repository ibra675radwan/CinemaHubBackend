using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.genre
{
    public class GenreRepositories : GenericRepositories<Genre> , iGenreRepositories
    {
        private readonly CinemaHubContext _context;
        public GenreRepositories(CinemaHubContext cinemaHubContext) : base(cinemaHubContext)
        {
            _context = cinemaHubContext?? throw new ArgumentNullException(nameof(cinemaHubContext));
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
        }
    }
}
