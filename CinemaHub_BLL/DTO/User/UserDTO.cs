using CinemaHub_BLL.DTO.Role;
using CinemaHub_BLL.DTO.UserWithCinema;
using CinemaHub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.User
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;
        public string? Username { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual RoleDto Role { get; set; } = null!;
        public int? CinemaId { get; set; }







    }
}
