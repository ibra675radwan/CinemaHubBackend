using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.Services.Genre;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GenreController : GenericController<GenreDTO>
    {

        private readonly iGenreService _iGenreService;

        public GenreController(iGenreService iGenreService): base(iGenreService) 
        {
            _iGenreService = iGenreService;
        }
    }

}
