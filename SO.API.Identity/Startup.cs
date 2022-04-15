using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SO.DataLayer.Identity.Model;
using Microsoft.EntityFrameworkCore;
using SO.DataLayer.Identity.Repositories;
using SO.BusinessLayer.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using SO.BusinessLayer.Identity.Configurations;

namespace SO.API.Identity 
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
        }

        static IdentityConfig LoadIdentityConfiguration() {
            IdentityConfig identityConfiguration = new IdentityConfig();
            Configuration.Bind(IdentityConfig.ConfigurationSectionPath, identityConfiguration);
            return identityConfiguration;
        }

        public static Lazy<IdentityConfig> IdentityConfigLazy = new Lazy<IdentityConfig>(LoadIdentityConfiguration);
        public static IdentityConfig IdentityConfiguration => IdentityConfigLazy.Value;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<DbContext, IdentityContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IdentityConfiguration.IssuerSigningKey.ToCharArray())),
                        ValidateAudience = IdentityConfiguration.ValidateAudience,
                        ValidAudience = IdentityConfiguration.ValidAudience,
                        ValidateIssuer = IdentityConfiguration.ValidateIssuer,
                        ValidIssuer = IdentityConfiguration.ValidIssuer,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            AddBaseServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            AddErrorMiddleware(app);

            app.UseHttpsRedirection();

            app.UseRouting();

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
