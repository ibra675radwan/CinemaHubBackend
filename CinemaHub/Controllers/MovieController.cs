using AutoMapper;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.DTO.User;
using CinemaHub_BLL.Services.CinemaService;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Genre;
using CinemaHub_BLL.Services.Movie;
using CinemaHub_BLL.wrapping;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieController : GenericController<MovieDto>
    {
        private readonly iMovieService _movieService;
        private readonly iGenreService _genreService;
        private readonly iCinemaService _cinemaService;
        private readonly iMoviesRepositories _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(iMovieService movieService, iGenreService iGenreService, iMoviesRepositories iMoviesRepositories ,iCinemaService iCinemaService, IMapper mapper) : base(movieService )
        {
            _movieService = movieService;
            _genreService = iGenreService;
            _movieRepository = iMoviesRepositories;
            _cinemaService = iCinemaService;
            _mapper = mapper;
        }
        [HttpGet("GetMovieByName")]
        public APIResponse<MovieDto> GetMovieByName(string name)
        {
            return _movieService.GetMovieByName(name);
        }
        [HttpPost("addMovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieDto movieDto)
        {
            if (movieDto == null || string.IsNullOrEmpty( movieDto.Genre.Name))
            {
                return BadRequest(new { message = "Genre information is required." });
            }
            if (movieDto == null || string.IsNullOrEmpty(movieDto.CinemaName)) {
                return BadRequest(new { message = "Cinema information is required." });


            }

            try
            {
                // Validate Genre - Fetch the genre by name
                var genreDto = await _genreService.GetGenreByNameAsync(movieDto.Genre.Name);
                var cinemaDto = await _cinemaService.GetCinemaByNameAsync(movieDto.CinemaName);
                if (genreDto == null)
                {
                    return BadRequest(new { message = $"Genre '{movieDto.Genre.Name}' not found." });
                }
                if ( cinemaDto == null)
                {
                    return BadRequest(new { message = $"Cinema '{movieDto.CinemaName}' not found." });

                }

                // Map MovieDTO to Movie entity
                var movie = _mapper.Map<Movie>(movieDto);

                // Assign the genre (use the genreId or other relevant data)
                movie.GenreId = genreDto.GenreId;
                movie.CinemaId = cinemaDto.CinemaId;

                // Add the movie to the database
                await _movieRepository.AddMovieAsync(movie);

               

                return Ok(new { message = "Movie added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

    }
}

