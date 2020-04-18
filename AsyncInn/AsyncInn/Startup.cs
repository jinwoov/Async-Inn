using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AsyncInn
{
    public class Startup
    {
        // properties that will be assigned for this startup
        public IConfiguration Configuration { get; }
        // making our configuration to be one that is passing
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();

            builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //Middleware
            services.AddMvc();

            // setting our database dependency
            services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //The below adds Newtonsoft JSON loop handling
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // Adding Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel Async", Version = "v1" });
            });


            // Adding transient dependency and connecting the interface to services
            services.AddTransient<IHotelManager, HotelService>();
            services.AddTransient<IAmenitiesManager, AmenitiesService>();
            services.AddTransient<IRoomManager, RoomService>();
            services.AddTransient<IHotelRoomManager, HotelRoomsService>();


        }

        /// <summary>
        /// configuration method to setting the home
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}

            /// using Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            // setting our default route to be home and using id if its available
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
