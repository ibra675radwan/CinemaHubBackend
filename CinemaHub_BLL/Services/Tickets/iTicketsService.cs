using CinemaHub_BLL.DTO.Ticket;
using CinemaHub_BLL.Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Tickets
{
    public interface iTicketsService : iGenericServices<TicketDto>
    {
    }
}
