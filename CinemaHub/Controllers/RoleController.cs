using CinemaHub_BLL.DTO.Role;
using CinemaHub_BLL.Services.Role;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RoleController : GenericController<RoleDto>
    {
        private readonly iRoleService _roleService;

        public RoleController(iRoleService roleService) : base(roleService) 
        {
            _roleService = roleService;
        }
    }
}
