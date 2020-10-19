using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Commands.Customer;

namespace HungryPizza.Servico.Validations.Repositories.Customer
{
    public class UpdateCustomerRepositoryValidation : CustomerValidation
    {
        public UpdateCustomerRepositoryValidation(ICustomerRepository repo) : base(repo)
        {
            ValidateIdCustomerExists();
        }
    }
}