using CinemaHub_BLL.DTO.Ticket;
using CinemaHub_BLL.Services.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TicketController : GenericController<TicketDto>
    {
        private readonly iTicketsService _ticketsService;

        public TicketController(iTicketsService ticketsService) : base(ticketsService) 
        {
            _ticketsService = ticketsService;
        }
    }
}
