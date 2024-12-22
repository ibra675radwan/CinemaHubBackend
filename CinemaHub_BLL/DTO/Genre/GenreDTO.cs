using CinemaHub_BLL.DTO.Movie;
using CinemaHub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Genre
{
    public class GenreDTO
    {
        public int GenreId { get; set; }

        public string Name { get; set; } = null!;

    }
}
