using AutoMapper;
using CinemaHub_BLL.DTO.UserWithCinema;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories.UserWithCinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.UserwithCinemas
{
    public class UserWithCinemaService : GenericServices<Userwithcinema, UserWithCinemaDTO>, IuserWithCinemaService
    {
        private readonly iUserWithCinemaRepositorie _repository;
        private readonly IMapper _mapper;

        public UserWithCinemaService(iUserWithCinemaRepositorie repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserWithCinemaDTO>> GetByUserIdAsync(int userId)
        {
            var userWithCinemas = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<List<UserWithCinemaDTO>>(userWithCinemas);
        }
    }

}

