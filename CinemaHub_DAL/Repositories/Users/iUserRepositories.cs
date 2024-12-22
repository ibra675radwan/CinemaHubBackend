using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Users
{
    public interface iUserRepositories : iGenericRepositories<User>
    {
        User GetUserByName(string name);
        User GetUserByUsernameAndPassword(string username, string password);
        Task<User> GetUserWithCinemaAsync(string username, string password);
        Task<User?> GetUserByUsernameAsync(string username);

        Task AddUserAsync(User user);
        Task<List<User>> GetAllUsersWithRolesAsync();  // New Method
    }
}
