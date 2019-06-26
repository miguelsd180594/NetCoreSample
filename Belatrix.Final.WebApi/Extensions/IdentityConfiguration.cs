using Belatrix.Final.WebApi.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Belatrix.Final.WebApi.Extensions
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString, x => x.MigrationsAssembly("Belatrix.Final.WebApi")))
                .BuildServiceProvider();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            return services;
        }
    }
}
