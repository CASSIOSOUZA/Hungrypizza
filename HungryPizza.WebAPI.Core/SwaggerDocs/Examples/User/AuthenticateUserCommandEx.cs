using HungryPizza.WebAPI.Core.ViewModels.Commands.User;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.User
{
    /// <summary>
    /// Metodo AuthenticateUserCommandEx
    /// </summary>
    public class AuthenticateUserCommandEx : IExamplesProvider<AuthenticateUserCommandVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public AuthenticateUserCommandVM GetExamples()
        {
            return new AuthenticateUserCommandVM
            {
                Email = "my@email.com",
                Password = "MY_NEW_PASSWORD",
            };
        }
    }
}