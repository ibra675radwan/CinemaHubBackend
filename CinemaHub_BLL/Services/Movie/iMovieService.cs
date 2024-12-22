using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.wrapping;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Movie
{
    public interface iMovieService : iGenericServices<MovieDto>
    {
        APIResponse<MovieDto> GetMovieByName(string name);
        Task AddMovieAsync(MovieDto movieDto);


    }
}
