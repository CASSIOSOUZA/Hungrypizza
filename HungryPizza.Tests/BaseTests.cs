using AutoMapper;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Mappers;
using HungryPizza.WebAPI.Core.Mappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace HungryPizza.Tests
{
    public class BaseTests
    {
        protected readonly AppSettings _appSettings;
        protected IMediator _mediator;
        protected IMapper _mapper;

        public BaseTests()
        {
            var appSettings = new AppSettings();
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build()
                .Bind(appSettings);

            _appSettings = appSettings;
            _mediator = new Mock<IMediator>().Object;
            GetServices();
        }

        protected void GetServices()
        {
            var services = new ServiceCollection();
            services.AddScoped(m => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToEntityMappingProfile());
                cfg.AddProfile(new ViewModelToCommandMappingProfile(_appSettings));
                cfg.AddProfile(new ViewModelToQueryMappingProfile(_appSettings));
            }).CreateMapper());

            var provider = services.BuildServiceProvider();
            _mapper = provider.GetService<IMapper>();
        }
    }
}