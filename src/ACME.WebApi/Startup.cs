using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ACME.WebApi.Middlewares;
using ACME.WebApi.Controllers;
using ACME.DataAccess;

namespace ACME.WebApi
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
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApplicationPart(typeof(CountriesController).Assembly)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ACMEContext>(options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString(Core.Constants.DefaultConnectionStringKeyName),
                        sqlOptions => sqlOptions.MigrationsAssembly(typeof(ACMEContext).GetTypeInfo().Assembly.GetName().Name)
                    );
                }, ServiceLifetime.Scoped);

            services.AddMemoryCache();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Constants.ApiPageVersion, new OpenApiInfo { Title = Constants.ApiPageTitle, Version = Constants.ApiPageVersion });
            });

            services.AddSingleton(Configuration);

            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {    
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), Constants.AppDirectoryName)),
                RequestPath = new PathString(string.Empty)
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(Constants.ApiPageJsonPath, Constants.ApiPageVersion);
                c.RoutePrefix = Constants.ApiPageUrlPrefix;
            });
        }
    }
}