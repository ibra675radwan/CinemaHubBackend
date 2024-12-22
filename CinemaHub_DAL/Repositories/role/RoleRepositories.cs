using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.role
{
    public class RoleRepositories : GenericRepositories<Role>, iRoleRepositories
    {
        private readonly CinemaHubContext _context;
        public RoleRepositories(CinemaHubContext cinemaHubContext) : base(cinemaHubContext)
        {
            _context = cinemaHubContext;    

        }
        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(g => g.RoleName == roleName);


        }
    }
}
