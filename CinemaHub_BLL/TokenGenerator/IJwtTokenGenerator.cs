using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.TokenGenerator
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateTokenAsync(LoginRequestDTO loginRequest);
    }

}
