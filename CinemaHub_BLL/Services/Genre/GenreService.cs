using AutoMapper;
using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Repositories._GenericRepositories;
using CinemaHub_DAL.Repositories.genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Genre
{
    using Entity = CinemaHub_DAL.Models.Genre;
    using Dto = CinemaHub_BLL.DTO.Genre.GenreDTO;
    public class GenreService : GenericServices<Entity , Dto> , iGenreService
        
    {
        private readonly iGenreRepositories _iGenreRepositories;
        private readonly IMapper _mapper;

        public GenreService(iGenreRepositories iGenreRepositories, IMapper mapper) : base(iGenreRepositories , mapper)
        {
            _iGenreRepositories = iGenreRepositories;
            _mapper = mapper;
        }
        public async Task<GenreDTO?> GetGenreByNameAsync(string name)
        {
            var genre = await _iGenreRepositories.GetGenreByNameAsync(name);
            if (genre == null)
                return null;

            // Map from the Genre entity to GenreDTO
            return new Dto
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }
    }
}
