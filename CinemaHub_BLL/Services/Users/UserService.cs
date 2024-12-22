using AutoMapper;
using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.DTO.Role;
using CinemaHub_BLL.DTO.User;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.TokenGenerator;
using CinemaHub_BLL.wrapping;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories.role;
using CinemaHub_DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Users
{
    using Entity = CinemaHub_DAL.Models.User;
    using dto = CinemaHub_BLL.DTO.User.UserDTO;
    public class UserService : GenericServices<Entity, dto>, iUserService
    {
        private readonly iUserRepositories _userRepository;
        private readonly iRoleRepositories _roleRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public UserService(iUserRepositories userRepository, IJwtTokenGenerator tokenGenerator,iRoleRepositories roleRepositories, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _roleRepository = roleRepositories;
        }



        public async Task<LoginRespondDto> AuthenticateUserAsync(string username, string password)
        {
            // Fetch the user from the repository
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.Password, password))
            {
                return null; // Authentication failed
            }

            // Map the user to LoginRespondDto
            var userResponse = new LoginRespondDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                CinemaId = user.CinemaId,
                 RoleId = user.RoleId,
            };

            // Generate JWT token
            var token = await _tokenGenerator.GenerateTokenAsync(new LoginRequestDTO
            {
                Username = user.Username,
                Password = password
            });

            // Add the token to the response
            userResponse.Token = token;

            return userResponse;
        }
        private bool VerifyPassword(string storedPassword, string inputPassword)
        {
            // If passwords are hashed, compare the hashes. Otherwise, perform a simple comparison.
            return storedPassword == inputPassword;
        }
        public APIResponse<dto> GetUserByName(string name)
        {
            var response = new APIResponse<dto>();
            var result = _userRepository.GetUserByName(name);
            response.Data = _mapper.Map<dto>(result);
            return response;



        }

        public async Task AddUserWithRoleAsync(UserDTO userDto)
        {
            var role = await _roleRepository.GetRoleByNameAsync(userDto.Role.RoleName);
            if (role == null)
            {
                throw new ArgumentException($"Genre '{userDto.Role.RoleName}' does not exist.");
            }
            // Map MovieDto to Movie entity
            var user = _mapper.Map<CinemaHub_DAL.Models.User>(userDto);

            // Assign associated entities
            user.RoleId = role.RoleId; // Assuming Genre has a GenreId

            // Save the movie
            await _userRepository.AddUserAsync(user);
        }

        public async Task<List<UserDTO>> GetAllUsersWithRolesAsync()
        {
            var users = await _userRepository.GetAllUsersWithRolesAsync();
            return _mapper.Map<List<UserDTO>>(users);  // Map List of Users to DTOs
        }

    }
}


