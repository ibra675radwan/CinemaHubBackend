using AutoMapper;
using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.DTO.cinemawithadmin;
using CinemaHub_BLL.DTO.Genre;
using CinemaHub_BLL.DTO.Login;
using CinemaHub_BLL.DTO.Movie;
using CinemaHub_BLL.DTO.Payment;
using CinemaHub_BLL.DTO.Review;
using CinemaHub_BLL.DTO.Role;
using CinemaHub_BLL.DTO.ShowTime;
using CinemaHub_BLL.DTO.Ticket;
using CinemaHub_BLL.DTO.User;
using CinemaHub_BLL.DTO.UserWithCinema;
using CinemaHub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() 
        {
           

           


            CreateMap<User , LoginRespondDto>().ReverseMap();
            CreateMap<User, LoginRequestDTO>().ReverseMap();

            CreateMap<TicketsTable , TicketDto>().ReverseMap();
            CreateMap<Showtime,ShowTimeDTO>().ReverseMap();
            CreateMap<Cinema , CinemaDTO>().ReverseMap();
            CreateMap<CinemaDTO, Cinema>().ReverseMap();

            CreateMap<Movie , MovieDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => new GenreDTO
            {
                GenreId = src.Genre.GenreId,
                Name = src.Genre.Name
            })); ;
            CreateMap<PaymentsTable , PaymentDTO>().ReverseMap();
            CreateMap<Review , ReviewDto>().ReverseMap();
            CreateMap<MovieDto, Movie>()
            .ForMember(dest => dest.GenreId, opt => opt.Ignore()) // Assigned manually
             .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.GenreId))

            .ForMember(dest => dest.CinemaId, opt => opt.Ignore());

            // MappingProfile.cs
            CreateMap<Cinema, CinemaWithAdminDTO>()
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Name));


            CreateMap<UserDTO, User>()
             .ForMember(dest => dest.Role, opt => opt.Ignore()) // Ignore to prevent AutoMapper issues
             .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId));

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => new RoleDto
                {
                    RoleId = src.Role.RoleId,
                    RoleName = src.Role.RoleName
                }));

            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Userwithcinema, UserWithCinemaDTO>().ReverseMap();

        }
    }
}
