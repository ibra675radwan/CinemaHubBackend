using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.DTO.cinemawithadmin;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.CinemaService
{
    public interface iCinemaService : iGenericServices<CinemaDTO>
    {


        Task AddCinemaWithAdminAsync(CinemaDTO cinemaDto);
        Task<CinemaWithAdminDTO?> GetCinemaAdminDtoAsync(int cinemaId);
         Task<CinemaDTO?> GetCinemaByNameAsync(string name);
        Task<bool> DeleteCinemaByNameAsync(string name);





    }
}
