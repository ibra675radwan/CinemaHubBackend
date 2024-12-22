using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.DTO.Role;
using CinemaHub_BLL.Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Role
{
    public interface iRoleService : iGenericServices<RoleDto>
    {
        Task<RoleDto?> GetRoleByNameAsync(string name);


    }
}
