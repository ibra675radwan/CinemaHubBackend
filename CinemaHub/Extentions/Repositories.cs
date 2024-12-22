using CinemaHub_BLL.Services.CinemaService;
using CinemaHub_BLL.Services.Genre;
using CinemaHub_BLL.Services.Movie;
using CinemaHub_BLL.Services.Payment;
using CinemaHub_BLL.Services.Review;
using CinemaHub_BLL.Services.Role;
using CinemaHub_BLL.Services.ShowTime;
using CinemaHub_BLL.Services.Tickets;
using CinemaHub_BLL.Services.Users;
using CinemaHub_BLL.Services.UserwithCinemas;
using CinemaHub_BLL.TokenGenerator;
using CinemaHub_DAL.Repositories.CinemA;
using CinemaHub_DAL.Repositories.genre;
using CinemaHub_DAL.Repositories.Movies;
using CinemaHub_DAL.Repositories.Payment;
using CinemaHub_DAL.Repositories.reviews;
using CinemaHub_DAL.Repositories.role;
using CinemaHub_DAL.Repositories.ShowTime;
using CinemaHub_DAL.Repositories.Tickets;
using CinemaHub_DAL.Repositories.Users;
using CinemaHub_DAL.Repositories.UserWithCinema;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace CinemaHub.Extentions
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<iUserRepositories, UserRepositories>();
            service.AddScoped<iTicketRepositorie, TicketRepositorie>();
            service.AddScoped<iShowTimeRepositorie, ShowTimeRepositorie>();
            service.AddScoped<iCinemaRepositorie, CinemaRepositorie>();
            service.AddScoped<iMoviesRepositories, MovieRepositories>();
            service.AddScoped<iPaymentRepositorie, PaymentRepositorie>();
            service.AddScoped<iReviewRepositories, ReviewRepositories>();
            service.AddScoped<iGenreRepositories, GenreRepositories>();
            service.AddScoped<iRoleRepositories, RoleRepositories>();
            service.AddScoped<iUserWithCinemaRepositorie, UserWithCinemaRepositorie>();

            return service;
        }
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<iUserService, UserService>();
            service.AddScoped<iTicketsService, TicketService>();
            service.AddScoped<iShowTimeService, ShowtimeService>();
            service.AddScoped<iCinemaService, CinemaService>();
            service.AddScoped<iMovieService, MovieService>();
            service.AddScoped<iPaymentService, PaymentService>();
            service.AddScoped<iReviewService, ReviewService>();
            service.AddScoped<iGenreService, GenreService>();
            service.AddScoped<iRoleService, RoleService>();
            service.AddScoped<IuserWithCinemaService, UserWithCinemaService>();
            service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            // Add Authorization middleware






            return service;

        }
    }
}
