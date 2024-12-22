using AutoMapper;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Tickets;
using CinemaHub_DAL.Repositories.ShowTime;
using CinemaHub_DAL.Repositories.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.ShowTime
{
    using Entity = CinemaHub_DAL.Models.Showtime;
    using Dto = CinemaHub_BLL.DTO.ShowTime.ShowTimeDTO;
    public class ShowtimeService : GenericServices<Entity , Dto> , iShowTimeService
    {
        private readonly iShowTimeRepositorie _iShowTimeRepositorie;
        private readonly IMapper _mapper;

        public ShowtimeService(iShowTimeRepositorie iShowTimeRepositorie, IMapper mapper) : base(iShowTimeRepositorie, mapper)
        {
            _iShowTimeRepositorie = iShowTimeRepositorie;
            _mapper = mapper;
        }
    }
}
