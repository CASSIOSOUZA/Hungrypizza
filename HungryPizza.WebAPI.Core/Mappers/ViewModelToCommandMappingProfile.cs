using AutoMapper;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Commands.Customer;
using HungryPizza.Servico.Commands.Request;
using HungryPizza.Servico.Commands.User;
using HungryPizza.WebAPI.Core.ViewModels.Commands.Customer;
using HungryPizza.WebAPI.Core.ViewModels.Commands.Request;
using HungryPizza.WebAPI.Core.ViewModels.Commands.User;

namespace HungryPizza.WebAPI.Core.Mappers
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelToCommandMappingProfile"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        public ViewModelToCommandMappingProfile(AppSettings appSettings)
        {
            #region Customer

            CreateMap<CreateCustomerCommandVM, CreateCustomerCommand>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<UpdateCustomerCommandVM, UpdateCustomerCommand>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));

            #endregion Customer

            #region User

            CreateMap<AuthenticateUserCommandVM, AuthenticateUserCommand>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));

            #endregion User

            #region Request

            CreateMap<RequestPizzaCommandVM, RequestPizzaCommand>();
            CreateMap<CreateRequestCommandVM, CreateRequestCommand>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));

            #endregion Request
        }
    }
}