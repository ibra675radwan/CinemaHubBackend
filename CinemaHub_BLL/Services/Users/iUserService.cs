using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.DTO.User;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.wrapping;
using CinemaHub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Users
{
    public interface iUserService:iGenericServices<UserDTO>
    {
        Task<LoginRespondDto> AuthenticateUserAsync(string username, string password);

        APIResponse<UserDTO> GetUserByName(string name);
        Task<List<UserDTO>> GetAllUsersWithRolesAsync();  // New Service Method

        Task AddUserWithRoleAsync(UserDTO userDTO);    
    }
}
