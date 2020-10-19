using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Entities;

namespace HungryPizza.Servico.Validations.Repositories.User
{
    public class AuthenticateUserRepositoryValidation : UserValidation
    {
        public AuthenticateUserRepositoryValidation(IUserRepository repo) : base(repo)
        {
            ValidateEmailNotExists();
        }
    }
}