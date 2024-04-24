using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SC4690_HFT_2023241.Logic.Classes;
using SC4690_HFT_2023241.Logic.Interfaces;
using SC4690_HFT_2023241.Models;
using SC4690_HFT_2023241.Repository;
using SC4690_HFT_2023241.Repository.Databases;
using SC4690_HFT_2023241.Repository.Interfaces;
using SC4690_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SC4690_HFT_2023241.Endpoint.Services;

namespace SC4690_HFT_2023241.Endpoint
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

            services.AddTransient<SmartDevicesDbContext, SmartDevicesDbContext>();
            services.AddTransient<IRepository<Owner>, OwnerRepository>();
            services.AddTransient<IRepository<Laptop>, LaptopRepository>();
            services.AddTransient<IRepository<SmartPhone>, SmartPhoneRepository>();
            services.AddTransient<IRepository<Tablet>, TabletRepository>();

            services.AddTransient<IOwnerLogic, OwnerLogic>();
            services.AddTransient<ILaptopLogic, LaptopLogic>();
            services.AddTransient<ISmartPhoneLogic, SmartPhoneLogic>();
            services.AddTransient<ITabletLogic, TabletLogic>();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SC4690_HFT_2023241.Endpoint", Version = "v1" });
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SC4690_HFT_2023241.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;

                var response = new { Msg = exception.Message };

                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x.AllowCredentials().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:18994"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
