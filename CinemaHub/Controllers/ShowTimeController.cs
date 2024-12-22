using CinemaHub_BLL.DTO.ShowTime;
using CinemaHub_BLL.Services.ShowTime;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ShowTimeController : GenericController<ShowTimeDTO>
    {
       private readonly iShowTimeService _iShowTimeService;

        public ShowTimeController(iShowTimeService iShowTimeService) : base(iShowTimeService) 
        {
            _iShowTimeService = iShowTimeService;
        }
    }
}
