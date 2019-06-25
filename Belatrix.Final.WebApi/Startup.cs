using Mysql = Belatrix.Final.WebApi.Repository.MySql;
using PostgreSql = Belatrix.Final.WebApi.RepositoryPostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Belatrix.Final.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            //services.AddDbContext<BelatrixFinalDbContext>(options =>
            //options.UseMySql(Configuration.GetConnectionString("mysql")));

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PostgreSql.BelatrixFinalDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"), x => x.MigrationsAssembly("Belatrix.Final.WebApi")))
                .BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
