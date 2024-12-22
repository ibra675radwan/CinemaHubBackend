using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.User;
using CinemaHub_DAL.Repositories.Users;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.TokenGenerator
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly iUserRepositories _userRepository;

        public JwtTokenGenerator(IConfiguration configuration, iUserRepositories iUserRepositories)
        {
            _configuration = configuration;
            _userRepository = iUserRepositories;
        }
        public async Task<string> GenerateTokenAsync(LoginRequestDTO loginRequest)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);

            if (user == null)
            {
                throw new ArgumentException("Invalid username.");
            }

            // Define JWT claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("RoleID", user.Role.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
