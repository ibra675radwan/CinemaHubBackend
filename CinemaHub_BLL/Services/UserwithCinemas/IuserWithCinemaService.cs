using CinemaHub_BLL.DTO.UserWithCinema;
using CinemaHub_BLL.Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.UserwithCinemas
{
    public interface IuserWithCinemaService : iGenericServices<UserWithCinemaDTO>
    {
        Task<List<UserWithCinemaDTO>> GetByUserIdAsync(int userId);

    }
}
