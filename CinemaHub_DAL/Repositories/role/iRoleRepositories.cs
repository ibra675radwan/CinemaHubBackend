using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.role
{
    public interface iRoleRepositories : iGenericRepositories<Role>
    {
        Task<Role?> GetRoleByNameAsync(string  roleName);


    }
}
