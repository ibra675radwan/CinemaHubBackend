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
        public async Task<IActionResult> AddMovie([FromForm] MovieDto movieDto, IFormFile? posterFile)
        {
            if (movieDto == null || string.IsNullOrEmpty(movieDto.Genre.Name))
            {
                return BadRequest(new { message = "Genre information is required." });
            }

            if (movieDto == null || string.IsNullOrEmpty(movieDto.CinemaName))
            {
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

                if (cinemaDto == null)
                {
                    return BadRequest(new { message = $"Cinema '{movieDto.CinemaName}' not found." });
                }

                // Handle Poster Upload
                string? posterUrl = null;
                if (posterFile != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "movies");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}_{posterFile.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await posterFile.CopyToAsync(fileStream);
                    }

                    posterUrl = $"/uploads/movies/{uniqueFileName}";
                }

                // Map MovieDTO to Movie entity
                var movie = _mapper.Map<Movie>(movieDto);
                movie.GenreId = genreDto.GenreId;
                movie.CinemaId = cinemaDto.CinemaId;
                movie.PosterUrl = posterUrl;

                // Add the movie to the database
                await _movieRepository.AddMovieAsync(movie);

                return Ok(new { message = "Movie added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        [HttpGet("GetMoviesByCinemaName")]
        public async Task<APIResponse<IEnumerable<MovieDto>>> GetMoviesByCinemaName(string cinemaName)
        {
            var result = new APIResponse<IEnumerable<MovieDto>>();
            try
            {
                var movies = await _movieService.GetMoviesByCinemaNameAsync(cinemaName);
                result.Data = movies;
                
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        [HttpDelete("DeleteMovieByTitle")]
        public async Task<IActionResult> DeleteMovieByTitle(string Title)
        {
            try
            {
                var result = await _movieService.DeleteMovieByNameAsync(Title);
                if (!result)
                {
                    return NotFound(new { message = $"Cinema with name '{Title}' not found." });
                }

                return Ok(new { message = $"Cinema with name '{Title}' deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        [HttpGet("DownloadImage")]
        public IActionResult DownloadImage(string imagePath)
        {
            try
            {
                // Base directory where your images are stored
                string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                // Full path to the image
                string fullPath = Path.Combine(baseDirectory, imagePath.TrimStart('/'));

                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound(new { message = "Image not found." });
                }

                // Read the image file
                var fileBytes = System.IO.File.ReadAllBytes(fullPath);
                string contentType = "application/octet-stream";

                // Infer the content type based on file extension
                var extension = Path.GetExtension(fullPath)?.ToLower();
                if (extension == ".jpg" || extension == ".jpeg") contentType = "image/jpeg";
                else if (extension == ".png") contentType = "image/png";
                else if (extension == ".gif") contentType = "image/gif";

                return File(fileBytes, contentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing the request.", details = ex.Message });
            }
        }
        [HttpGet("GetAllMoviesWithCinema")]
        public async Task<APIResponse<IEnumerable<MovieDto>>> GetAllMoviesWithCinema()
        {
            var result = new APIResponse<IEnumerable<MovieDto>>();

            var movies = await _movieService.GetAllMoviesWithCinemaAsync();
            result.Data = movies;

            return result;
        }

        [HttpGet("suggest/{firstLetter}")]
        public async Task<IActionResult> SuggestMoviesByFirstLetter(char firstLetter)
        {
            var movies = await _movieService.SuggestMoviesByFirstLetterAsync(firstLetter);

            if (movies == null || !movies.Any())
                return NotFound("No movies found for the given letter.");

            return Ok(movies);
        }



    }
}

