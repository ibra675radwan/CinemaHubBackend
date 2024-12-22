using CinemaHub_BLL.DTO.ShowTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Ticket
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public decimal Price { get; set; }

        public int ShowtimeId { get; set; }
        public ShowTimeDTO Showtime { get; set; }
    }
}
