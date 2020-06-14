using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabidBike.API.Extensions;
using RabidBike.Common.Middleware;
using RabidBike.Data.Context;
using RabidBike.Data.Extensions;
using RabidBike.Services.Extensions;

namespace RabidBike.API
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
            // Database Context
            services.AddDbContext<RabidBikeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RabidBikeConnectionString")));

            // call extension methods
            services.RegisterJwtSettings(Configuration);
            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterIdentity();
            services.RegisterCors();
            services.RegisterMapper();

            services.AddActionFilters();

            services.AddControllers();

            services.AddPolicyAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            //app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseCors("EnableCORS");

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
