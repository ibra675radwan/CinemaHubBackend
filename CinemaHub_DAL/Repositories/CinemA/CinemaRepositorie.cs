using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.CinemA
{
    public class CinemaRepositorie : GenericRepositories<Cinema>, iCinemaRepositorie
    {
        private readonly CinemaHubContext _context;
        public CinemaRepositorie(CinemaHubContext cinemaHubContext) : base(cinemaHubContext)
        {
            _context = cinemaHubContext;

        }
        public async Task AddCinemaAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);  // Save Cinema First
            await _context.SaveChangesAsync();
        }
        public async Task AddCinemaWithAdminAsync(Cinema cinema, Userwithcinema userWithCinema)
        {
            // Add the cinema and the relationship entry
            await _context.Cinemas.AddAsync(cinema);
            await _context.Userwithcinemas.AddAsync(userWithCinema);
            await _context.SaveChangesAsync();
        }

        // CinemaRepositorie.cs
        public async Task<Cinema?> GetCinemaWithUsersAsync(int cinemaId)
        {
            return await _context.Cinemas
                .Include(c => c.Userwithcinemas)
                .ThenInclude(uc => uc.User)
                .FirstOrDefaultAsync(c => c.CinemaId == cinemaId);
        }

        public async Task<Cinema?> GetCinemaByNameAsync(string name)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(c => c.Name == name);
        }

    }
   
}
