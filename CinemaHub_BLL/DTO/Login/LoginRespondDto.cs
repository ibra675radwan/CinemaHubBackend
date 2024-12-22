using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Login
{
    public class LoginRespondDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;


        public int RoleId { get; set; }

        public string Username { get; set; } = null!;

        public int? CinemaId { get; set; }
        public string Token { get; set; } = null!;

    }
}
