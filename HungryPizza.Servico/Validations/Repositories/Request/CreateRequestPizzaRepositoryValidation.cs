using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Entities;

namespace HungryPizza.Servico.Validations.Repositories.Request
{
    public class CreateRequestPizzaRepositoryValidation : RequestPizzaValidation
    {
        public CreateRequestPizzaRepositoryValidation(IPizzaRepository repo) : base(repo)
        {
            ValidateIdPizzaFirstHalfExists();
            ValidateIdPizzaSecondHalfExists();
        }
    }
}