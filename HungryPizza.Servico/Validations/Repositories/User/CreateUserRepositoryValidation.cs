using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Entities;

namespace HungryPizza.Servico.Validations.Repositories.User
{
    public class CreateUserRepositoryValidation : UserValidation
    {
        public CreateUserRepositoryValidation(IUserRepository repo) : base(repo)
        {
            ValidateEmailNotExists();
        }
    }
}