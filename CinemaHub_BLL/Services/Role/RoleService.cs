using AutoMapper;
using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Repositories.role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Role
{
    using Entity = CinemaHub_DAL.Models.Role;
    using Dto = CinemaHub_BLL.DTO.Role.RoleDto;
    public class RoleService : GenericServices<Entity , Dto> , iRoleService
    {
        private readonly iRoleRepositories _iRoleRepositories;
        private readonly IMapper _mapper;

        public RoleService(iRoleRepositories iRoleRepositories, IMapper mapper) : base (iRoleRepositories , mapper)
        {
            _iRoleRepositories = iRoleRepositories;
            _mapper = mapper;
        }

        public async Task<Dto?> GetRoleByNameAsync(string name)
        {
            var role = await _iRoleRepositories.GetRoleByNameAsync(name);
            if (role == null)
                return null;

            // Map from the Genre entity to GenreDTO
            return new Dto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
        }
    }
}
