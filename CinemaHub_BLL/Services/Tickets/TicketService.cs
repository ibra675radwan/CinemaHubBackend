using AutoMapper;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Users;
using CinemaHub_DAL.Repositories.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Tickets
{
    using Entity = CinemaHub_DAL.Models.TicketsTable;
    using dto = CinemaHub_BLL.DTO.Ticket.TicketDto;
    public class TicketService : GenericServices <Entity , dto>, iTicketsService
    {
        private readonly iTicketRepositorie ticketRepositorie;
        private readonly IMapper _mapper;

        public TicketService(iTicketRepositorie ticketRepositorie, IMapper mapper) : base(ticketRepositorie, mapper)
        {
            this.ticketRepositorie = ticketRepositorie;
            _mapper = mapper;
        }
    }
}
