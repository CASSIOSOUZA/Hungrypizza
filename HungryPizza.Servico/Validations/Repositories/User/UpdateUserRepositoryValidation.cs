using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Entities;

namespace HungryPizza.Servico.Validations.Repositories.User
{
    public class UpdateUserRepositoryValidation : UserValidation
    {
        public UpdateUserRepositoryValidation(IUserRepository repo) : base(repo)
        {
            ValidateIdUserExists();
            ValidateEmailNotExistsForDifferentUser();
        }
    }
}