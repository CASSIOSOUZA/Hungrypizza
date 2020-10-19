using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Validations.Commands.User;

namespace HungryPizza.Servico.Commands.User
{
    public class AuthenticateUserCommand : CommandQuery
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public AuthenticateUserCommand(string email, string password,
            AppSettings appSettings) : base(appSettings)
        {
            Email = email;
            Password = password;
        }

        public bool IsValid()
        {
            Validate(this, new AuthenticateUserCommandValidation());
            return Valid;
        }
    }
}