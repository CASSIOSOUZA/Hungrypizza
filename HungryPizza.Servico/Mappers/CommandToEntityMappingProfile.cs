using AutoMapper;
using HungryPizza.Servico.Commands.Customer;
using HungryPizza.Servico.Commands.Request;
using HungryPizza.Servico.Commands.User;
using HungryPizza.Servico.Entities;

namespace HungryPizza.Servico.Mappers
{
    public class CommandToEntityMappingProfile : Profile
    {
        public CommandToEntityMappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<CreateCustomerCommand, User>();
            //.ForMember(m => m.Name, n => n.MapFrom(f => f.Name))
            //.ForMember(m => m.Address, n => n.MapFrom(f => f.Address))
            //.ForMember(m => m.User, n => n.MapFrom(f => new User(0, f.Email, f.Password, true)));

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(m => m.Id, n => n.MapFrom(f => f.IdCustomer));
            CreateMap<UpdateCustomerCommand, User>();
            //.ForMember(m => m.Name, n => n.MapFrom(f => f.Name))
            //.ForMember(m => m.Address, n => n.MapFrom(f => f.Address));
            //.ForMember(m => m.User, n => n.MapFrom(f => new User(0, f.Email, f.Password, f.Active)));

            CreateMap<AuthenticateUserCommand, User>();

            CreateMap<CreateRequestCommand, Request>();
            //.ForMember(m => m.Customer, n => n.MapFrom(f => new Customer(f.Customer.IdCustomer ?? 0, 0, null, f.Customer.Address)));
        }
    }
}