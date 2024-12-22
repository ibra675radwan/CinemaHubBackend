using CinemaHub_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaHub.Extentions
{
    public static class StartupExtention
    {

        public static IServiceCollection addDb(this IServiceCollection service , ConfigurationManager config)
        {
            var ConnectionString = config.GetConnectionString("DefaultConnection");
            service.AddDbContext<CinemaHubContext>(options => options.UseSqlServer(ConnectionString));
            return service;


        }
        
    }
}
