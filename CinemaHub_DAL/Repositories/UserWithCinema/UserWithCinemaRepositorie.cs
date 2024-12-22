using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.UserWithCinema
{
    public class UserWithCinemaRepositorie : GenericRepositories<CinemaHub_DAL.Models.Userwithcinema> , iUserWithCinemaRepositorie
    {
        private readonly CinemaHubContext _context;

        public UserWithCinemaRepositorie(CinemaHubContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Userwithcinema>> GetByUserIdAsync(int userId)
        {
            return await _context.Userwithcinemas
                .Include(uc => uc.User)    // Correct Reference
                .Include(uc => uc.Cinema)  // Correct Reference
                .Where(uc => uc.UserId == userId)
                .ToListAsync();
        }
    }
}
