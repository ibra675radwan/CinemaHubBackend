using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Genre
{
    public interface iGenreService : iGenericServices<GenreDTO>
    {

        Task<GenreDTO?> GetGenreByNameAsync(string name);




    }
}
