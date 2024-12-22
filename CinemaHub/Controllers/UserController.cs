using AutoMapper;
using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.DTO.User;
using CinemaHub_BLL.Services.Genre;
using CinemaHub_BLL.Services.Movie;
using CinemaHub_BLL.Services.Role;
using CinemaHub_BLL.Services.Users;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories.Movies;
using CinemaHub_DAL.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : GenericController<UserDTO>
    {
        private readonly iUserService _userService;
        private readonly iRoleService _roleService;
        private readonly iUserRepositories _userRepository;
        private readonly IMapper _mapper;

        public UserController(iUserService userService, iRoleService iroleService, iUserRepositories iUserRepositories, IMapper mapper) : base(userService)
        {
            _userService = userService;
            _roleService = iroleService;
            _userRepository = iUserRepositories;
            _mapper = mapper;
        }


        [HttpPost("addUserWithRole")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Role.RoleName))
            {
                return BadRequest(new { message = "Role information is required." });
            }

            try
            {
                // Fetch Role by Name
                var roleDto = await _roleService.GetRoleByNameAsync(userDto.Role.RoleName);

                if (roleDto == null)
                {
                    return BadRequest(new { message = $"Role '{userDto.Role.RoleName}' not found." });
                }

                // Map UserDTO to User and Assign RoleId
                var user = _mapper.Map<User>(userDto);
                user.RoleId = roleDto.RoleId;

                // Add the User to the Database
                await _userRepository.AddUserAsync(user);

                // Reload the User from the Database with Role Populated
                var createdUser = await _userRepository.GetUserByUsernameAsync(user.Username);

                var createdUserDto = _mapper.Map<UserDTO>(createdUser);

                return Ok(new
                {
                    message = "User added successfully.",
                    data = createdUserDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }


    
    [HttpGet("getAllUsersWithRoles")]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            try
            {
                var users = await _userService.GetAllUsersWithRolesAsync();
                return Ok(new { message = "Users retrieved successfully.", data = users });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}