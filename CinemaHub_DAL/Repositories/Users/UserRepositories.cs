using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Users
{
    public class UserRepositories : GenericRepositories<User>, iUserRepositories
    {
        private readonly CinemaHubContext _context;
        public UserRepositories(CinemaHubContext context): base(context) 
        {
        
        _context = context;
        }
        public User GetUserByName(string name)
        {
            var result = _dbSet.Where(x => x.Name == name).FirstOrDefault();
            return result;
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            // Assuming password is stored as a hashed value
            return _context.Users.Include(u=> u.Role).FirstOrDefault(u => u.Username == username && u.Password == password); // For production, use hashed password comparison.
        }
        public async Task<User> GetUserWithCinemaAsync(string username, string password)
        {
            return await _context.Users
                .Include(u => u.Cinema) // Include associated Cinema
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Role)  // Include Role for User
                .FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user); // Add the movie entity to the context
            await _context.SaveChangesAsync(); // Save changes to the database
        }

        public async Task<List<User>> GetAllUsersWithRolesAsync()
        {
            return await _context.Users
                .Include(u => u.Role)  // Include Role Data
                .ToListAsync();
        }
    }
}
