using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Commands.Customer;

namespace HungryPizza.Servico.Validations.Repositories.Request
{
    public class CreateRequestCustomerRepositoryValidation : CustomerValidation
    {
        public CreateRequestCustomerRepositoryValidation(ICustomerRepository repo) : base(repo)
        {
            ValidateIdCustomerExists();
        }
    }
}