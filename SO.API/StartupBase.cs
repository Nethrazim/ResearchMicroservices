using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using SO.API.Middleware;

namespace SO.API
{
    public class StartupBase
    {
        protected IConfiguration Configuration { get; set; }
        public StartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void AddBaseServices(IServiceCollection services, string title)
        {
            //services.AddSwaggerGen();
        }

        public void AddErrorMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public void ConfigureBaseServices(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "API Version 1");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}
