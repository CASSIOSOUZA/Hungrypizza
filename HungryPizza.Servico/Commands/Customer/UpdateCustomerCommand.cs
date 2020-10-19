using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Commands.Customer;
using HungryPizza.Servico.Validations.Repositories.Customer;
using HungryPizza.Servico.Validations.Repositories.User;

namespace HungryPizza.Servico.Commands.Customer
{
    public class UpdateCustomerCommand : CommandQuery
    {
        public int IdCustomer { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public bool Active { get; private set; }

        public UpdateCustomerCommand(
            int idCustomer, string name, string email, string password, string address, bool active,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Active = active;
        }

        public bool IsValid()
        {
            Validate(this, new UpdateCustomerCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.Customer customer, ICustomerRepository customerRepository)
        {
            Validate(customer, new UpdateCustomerRepositoryValidation(customerRepository));
            return Valid;
        }

        public bool IsRepositoryValid(Entities.User user, IUserRepository userRepository)
        {
            Validate(user, new UpdateUserRepositoryValidation(userRepository));
            return Valid;
        }
    }
}