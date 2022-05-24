using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SO.API.Institution.Messaging.Consumers;
using SO.BusinessLayer.Institution.Services;
using SO.BusinessLayer.Messaging.Events;
using SO.DataLayer.Institution.Model;
using SO.DataLayer.Institution.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.API.Institution
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<DbContext, InstitutionContext>();

            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();


            services.AddScoped<UserChangedConsumer>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdasdasdadsadasdsaasdasdsadasasdasd".ToCharArray())),
                        ValidateAudience = true,
                        ValidAudience = "ResearchMicroservices",
                        ValidateIssuer = true,
                        ValidIssuer = "ResearchMicroservices",
                        ClockSkew = TimeSpan.Zero
                    };
                });

            AddBaseServices(services);

            services.AddMassTransit(x => {
                x.UsingRabbitMq((context, config) => {
                    config.Host("amqp://guest:guest@localhost:5672");
                    config.ConfigureEndpoints(context);
                });

                x.AddConsumer<UserChangedConsumer>();
                x.AddConsumer<EventChangedConsumer>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AddErrorMiddleware(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowedSpecificOrigins");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureBaseServices(app);
        }
    }
}
