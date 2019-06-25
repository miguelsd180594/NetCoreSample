using Belatrix.Final.WebApi.Models;
using Belatrix.Final.WebApi.Repository;
using Belatrix.Final.WebApi.Repository.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostgreSql = Belatrix.Final.WebApi.Repository.PostgreSql;

namespace Belatrix.Final.WebApi.Extensions
{
    public static class ConfigureDI
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<Mysql.BelatrixFinalDbContext>(options =>
            //options.UseMySql(Configuration.GetConnectionString("mysql")));

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PostgreSql.BelatrixFinalDbContext>(opt => opt.UseNpgsql(connectionString, x => x.MigrationsAssembly("Belatrix.Final.WebApi")))
                .BuildServiceProvider();

            services.AddTransient<IRepository<Album>, GenericRepository<Album>>();
            services.AddTransient<IRepository<Artist>, GenericRepository<Artist>>();
            services.AddTransient<IRepository<Customer>, GenericRepository<Customer>>();
            services.AddTransient<IRepository<Employee>, GenericRepository<Employee>>();
            services.AddTransient<IRepository<Genre>, GenericRepository<Genre>>();
            services.AddTransient<IRepository<Invoice>, GenericRepository<Invoice>>();
            services.AddTransient<IRepository<InvoiceLine>, GenericRepository<InvoiceLine>>();
            services.AddTransient<IRepository<MediaType>, GenericRepository<MediaType>>();
            services.AddTransient<IRepository<Playlist>, GenericRepository<Playlist>>();
            services.AddTransient<IRepository<PlaylistTrack>, GenericRepository<PlaylistTrack>>();
            services.AddTransient<IRepository<Track>, GenericRepository<Track>>();

            return services;
        }
    }
}
