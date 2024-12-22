using CinemaHub_BLL.DTO.UserWithCinema;
using CinemaHub_BLL.Services.UserwithCinemas;
using CinemaHub_BLL.Services.UserwithCinemas;
using CinemaHub_DAL.Repositories.UserWithCinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithCinemaController : GenericController<UserWithCinemaDTO>
    {
        private readonly IuserWithCinemaService _service;
        private readonly iUserWithCinemaRepositorie _iUserWithCinemaRepositorie;
        public UserWithCinemaController(IuserWithCinemaService service , iUserWithCinemaRepositorie iUserWithCinemaRepositorie) : base (service) 
        {
            _service = service;
            _iUserWithCinemaRepositorie = iUserWithCinemaRepositorie;
        }

       
       

        // Get by User ID
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var data = await _service.GetByUserIdAsync(userId);
            return Ok(data);
        }

      
    }
}
