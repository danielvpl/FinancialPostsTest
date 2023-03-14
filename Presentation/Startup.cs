using AutoMapper;
using Data.Context;
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Reflection;

namespace FinancialApiTest
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
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddDbContext<ContextApp>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"))
            );

            DependencyInjection.AddConfigurations(services);

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "FinancialPostsApi",
                    Version = "v1",
                    Description = "Financial Posts API - Projeto de Teste ASP.Net Core",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Daniel Viana Ponce de Leon",
                        Url = new Uri("https://github.com/danielvpl/FinancialPostsTest"),
                        Email = "danielvpl@gmail.com"
                    }
                });

                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    opt.IncludeXmlComments(xmlDocumentPath);
                }
            });

            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Data.Config.MapperProfile());
                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddLogging();

            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinancialApiTest V1");                
            });

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
