using AutoMapper;
using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Genre;
using CinemaHub_BLL.wrapping;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using CinemaHub_DAL.Repositories.CinemA;
using CinemaHub_DAL.Repositories.genre;
using CinemaHub_DAL.Repositories.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Movie
{
    using Entity = CinemaHub_DAL.Models.Movie;
    using Dto = CinemaHub_BLL.DTO.Movie.MovieDto;
    public class MovieService : GenericServices<Entity , Dto> , iMovieService
    {
        private readonly iMoviesRepositories _repository;
        private readonly iCinemaRepositorie _cinemaRepository;
        private readonly IMapper _mapper;
        private readonly iGenreService _genreService;
        private readonly iGenreRepositories _genreRepositories;

        public MovieService(iMoviesRepositories repository,iGenreService genreService,iGenreRepositories iGenreRepositories,iCinemaRepositorie iCinemaRepositorie ,IMapper mapper) : base (repository , mapper) 
        {
            _repository = repository;
            _mapper = mapper;
            _cinemaRepository = iCinemaRepositorie;
            _genreService = genreService;
            _genreRepositories = iGenreRepositories;
        }


        public APIResponse<Dto>GetMovieByName(string name)
        {
            var response = new APIResponse<Dto>();
            var result = _repository.GetMovieByName(name);
            response.Data = _mapper.Map<Dto>(result);
            return response;



        }
        public async Task AddMovieAsync(MovieDto movieDto)
        {
            // Validate the genre
            var genre = await _genreRepositories.GetGenreByNameAsync(movieDto.Genre.Name);
            if (genre == null)
            {
                throw new ArgumentException($"Genre '{movieDto.Genre.Name}' does not exist.");
            }

            // Validate the cinema
            var cinema = await _cinemaRepository.GetCinemaByNameAsync(movieDto.CinemaName);
            if (cinema == null)
            {
                throw new ArgumentException($"Cinema '{movieDto.CinemaName}' does not exist.");
            }

            // Map MovieDto to Movie entity
            var movie = _mapper.Map<CinemaHub_DAL.Models.Movie>(movieDto);

            // Assign associated entities
            movie.GenreId = genre.GenreId; // Assuming Genre has a GenreId
            movie.CinemaId = cinema.CinemaId; // Assuming Cinema has a CinemaId

            // Save the movie
            await _repository.AddMovieAsync(movie);
        }

        public async Task<List<MovieDto>> GetMoviesByCinemaNameAsync(string cinemaName)
        {
            var movies = await _repository.GetMoviesByCinemaNameAsync(cinemaName);






            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<bool> DeleteMovieByNameAsync(string title)
        {
            return await _repository.DeleteMovieByNameAsync(title);
        }

        public async Task<List<MovieDto>> GetAllMoviesWithCinemaAsync()
        {
            var movies = await _repository.GetAllMoviesWithCinemaAsync();

            // Map movies to MovieDTO, including CinemaName and Genre
            var movieDTOs = movies.Select(movie => new MovieDto
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Rating = movie.Rating,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl,
                CinemaName = movie.Cinema != null ? movie.Cinema.Name : null,
               

            }).ToList();

            return movieDTOs;
        }

        public async Task<List<MovieDto>> SuggestMoviesByFirstLetterAsync(char firstLetter)
        {
            var movies = await _repository.SuggestMoviesByFirstLetterAsync(firstLetter);
            return _mapper.Map<List<MovieDto>>(movies); // Use AutoMapper if applicable
        }



    }
}


