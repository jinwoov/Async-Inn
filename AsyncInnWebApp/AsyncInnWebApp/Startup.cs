using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInnWebApp.Models.Interfaces;
using AsyncInnWebApp.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncInnWebApp
{
    public class Startup
    {
        /// <summary>
        /// Using dependency
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // using MVC
            services.AddMvc();

            services.AddTransient<IHotelManager, HotelService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            /// Sets the default routing of our request
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            }
            );
        }
    }
}
