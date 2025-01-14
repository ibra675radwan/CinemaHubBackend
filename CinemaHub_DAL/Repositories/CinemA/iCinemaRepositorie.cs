using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.CinemA
{
    public interface iCinemaRepositorie: iGenericRepositories<Cinema>
    {

        Task AddCinemaAsync(Cinema cinema);
        Task AddCinemaWithAdminAsync(Cinema cinema, Userwithcinema userWithCinema);

        Task<Cinema?> GetCinemaWithUsersAsync(int cinemaId);
        Task<Cinema?> GetCinemaByNameAsync(string name);
        Task<bool> DeleteCinemaByNameAsync(string name);



    }
}
