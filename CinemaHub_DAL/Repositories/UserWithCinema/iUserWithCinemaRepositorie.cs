using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.UserWithCinema
{
    public interface iUserWithCinemaRepositorie : iGenericRepositories<CinemaHub_DAL.Models.Userwithcinema>
    {
        Task<List<Userwithcinema>> GetByUserIdAsync(int userId);
    }
}
