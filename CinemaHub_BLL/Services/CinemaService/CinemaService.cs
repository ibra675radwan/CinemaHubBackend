using AutoMapper;
using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.DTO.cinemawithadmin;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using CinemaHub_DAL.Repositories.CinemA;
using CinemaHub_DAL.Repositories.Users;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaHub_BLL.DTO.Genre;

namespace CinemaHub_BLL.Services.CinemaService
{
    using Entity = CinemaHub_DAL.Models.Cinema;
    using Dto = CinemaHub_BLL.DTO.Cinema.CinemaDTO;
    public class CinemaService : GenericServices<Entity, Dto>, iCinemaService
    {
        private readonly iCinemaRepositorie _iCinemaRepositorie;
        private readonly IMapper _mapper;
        private readonly iUserRepositories _userRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly CinemaWithAdminDTO _withAdmin;

        public CinemaService(iCinemaRepositorie iCinemaRepositorie,iUserRepositories userRepositories, IHttpContextAccessor httpContext, IMapper mapper) : base(iCinemaRepositorie , mapper) 
        {
            _iCinemaRepositorie = iCinemaRepositorie;
            _mapper = mapper;
            _userRepository = userRepositories;
            _httpContext = httpContext;
        }
        public async Task AddCinemaWithAdminAsync(CinemaDTO cinemaDto)
        {
            // Extract Username from Token in HttpContext
            var username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid token: Username not found.");
            }

            // Validate Admin
            var admin = await _userRepository.GetUserByUsernameAsync(username);
            if (admin == null)
            {
                throw new ArgumentException($"User '{username}' not found.");
            }

            // Map DTO to Entity
            var cinema = _mapper.Map<Cinema>(cinemaDto);

            // Save Cinema First
            await _iCinemaRepositorie.AddCinemaAsync(cinema);

            // Create Intermediary Record
            var userWithCinema = new Userwithcinema
            {
                UserId = admin.UserId,
                CinemaId = cinema.CinemaId  // Ensure this is set after saving the cinema
            };

            // Save the Intermediary Record
        }



        // CinemaService.cs
        public async Task<CinemaWithAdminDTO?> GetCinemaAdminDtoAsync(int cinemaId)
        {
            // Fetch the cinema with its users
            var cinema = await _iCinemaRepositorie.GetCinemaWithUsersAsync(cinemaId);
            if (cinema == null) return null;

            // Extract the first user as the admin
            var admin = cinema.Users.FirstOrDefault();
            if (admin == null) return null;

            // Return DTO
            return new CinemaWithAdminDTO
            {
                CinemaId = cinema.CinemaId,
                CinemaName = cinema.Name,
                AdminName = admin.Name,
                AdminUsername = admin.Username
            };
        }

        public async Task<CinemaDTO?> GetCinemaByNameAsync(string name)
        {
            var cinema = await _iCinemaRepositorie.GetCinemaByNameAsync(name);
            if (cinema == null)
                return null;

            // Map from the Genre entity to GenreDTO
            return new Dto
            {
                CinemaId = cinema.CinemaId,
                Name = cinema.Name
            };
        }


        public async Task<bool> DeleteCinemaByNameAsync(string name)
        {
            return await _iCinemaRepositorie.DeleteCinemaByNameAsync(name);
        }



    }
}
