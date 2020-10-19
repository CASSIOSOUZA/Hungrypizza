using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Commands.Customer;
using HungryPizza.Servico.Validations.Repositories.User;

namespace HungryPizza.Servico.Commands.Customer
{
    public class CreateCustomerCommand : CommandQuery
    {
        public CreateCustomerCommand(string name, string email, string password, string address,
            AppSettings appSettings) : base(appSettings)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }

        public bool IsValid()
        {
            Validate(this, new CreateCustomerCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.User user, IUserRepository userRepository)
        {
            Validate(user, new CreateUserRepositoryValidation(userRepository));
            return Valid;
        }
    }
}