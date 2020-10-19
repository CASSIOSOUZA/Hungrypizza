using AutoMapper;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Repositorio.Context;
using HungryPizza.Repositorio.Repositories;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Mappers;
using HungryPizza.WebAPI.Core.Mappers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;

namespace HungryPizza.WebAPI.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);
            services.AddControllers();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddSwaggerGen(aux =>
            {
                aux.SwaggerDoc("v1", new OpenApiInfo { Title = "Hungry Pizza Web API", Version = "v1" });
                aux.ExampleFilters();
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "HungryPizza.xml");
                aux.IncludeXmlComments(filePath);
            });

            services.AddDbContextPool<SQLContext>(options => options
                .UseMySql(appSettings.ConnectionStrings.DefaultConnection, mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(1, 0, 0), ServerType.MySql)
            ));

            services.AddScoped(m => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToEntityMappingProfile());
                cfg.AddProfile(new ViewModelToCommandMappingProfile(appSettings));
                cfg.AddProfile(new ViewModelToQueryMappingProfile(appSettings));
            }).CreateMapper());

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IRequestPizzaRepository, RequestPizzaRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMediatR(
                Assembly.Load("HungryPizza.WebAPI.Core"),
                Assembly.Load("HungryPizza.Servico")
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger().UseSwaggerUI(aux =>
            {
                aux.SwaggerEndpoint("/swagger/v1/swagger.json", "Hungry Pizza API V1");
                aux.RoutePrefix = "swagger";
            });
        }
    }
}