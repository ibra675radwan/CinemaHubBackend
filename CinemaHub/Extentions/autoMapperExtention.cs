
using CinemaHub_BLL.Mapping;

namespace CinemaHub.Extentions
{
    public static class autoMapperExtention
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection service)
        {
            
            service.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }, typeof(Program));
            return service;
        }
    }
}
    