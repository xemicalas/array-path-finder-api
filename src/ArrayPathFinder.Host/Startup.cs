using System;
using System.IO;
using System.Reflection;
using ArrayPathFinder.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ArrayPathFinder.Host
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Array Path Finder API",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var contractsXmlFile = "ArrayPathFinder.WebApi.Contracts.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var contractsXmlPath = Path.Combine(AppContext.BaseDirectory, contractsXmlFile);

                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(contractsXmlPath);
            });

            services.AddSingleton<IPathCalculationService>(provider => new CachedPathCalculationService(new PathCalculationService()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Array Path Finder API V1");
            });

            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}