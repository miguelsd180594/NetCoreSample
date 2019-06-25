using AutoMapper;
using Belatrix.Final.WebApi.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Belatrix.Final.WebApi.Extensions
{
    public static class AutomapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ArtistProfile>();
            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            return services;
        }
    }
}
