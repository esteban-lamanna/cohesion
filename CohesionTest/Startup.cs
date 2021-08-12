using CohesionTest.Configuration;
using CohesionTest.Repository;
using CohesionTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CohesionTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<ApplicationOptions>(Configuration.GetSection(ApplicationOptions.Section));

            services.AddTransient<IServiceRequestService, ServiceRequestService>();
            services.AddTransient<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INotificationService, NotificationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}