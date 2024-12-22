using CinemaHub_BLL.DTO.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Movie
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        public string? Title { get; set; }

        public DateOnly? ReleaseDate { get; set; }

        public int? Duration { get; set; }

        public decimal? Rating { get; set; }

        public GenreDTO Genre { get; set; } = null!; // Genre is a GenreDTO, not just a string

        public string? Description { get; set; }
        public string CinemaName { get; set; } = null!;





    }
}
