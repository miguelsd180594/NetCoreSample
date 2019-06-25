using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Belatrix.Final.WebApi.Extensions
{
    public static class SwashbuckleConfiguration
    {
        public static IServiceCollection AddSwashbuckle(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Belatrix Final Project API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });

            return services;
        }
    }
}
