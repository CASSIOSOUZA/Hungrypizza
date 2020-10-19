using AutoMapper;
using HungryPizza.Servico.Commands.User;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.User;
using HungryPizza.WebAPI.Core.ViewModels.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediatR">The mediat r.</param>
        /// <param name="mapper">The mapper.</param>
        public UserController(IMediator mediatR, IMapper mapper) : base(mediatR, mapper) { }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns>Object AuthenticateUserCommandVM. </returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(AuthenticateUserCommandVM), typeof(AuthenticateUserCommandEx))]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserCommandVM vm)
        {
            return await Send<AuthenticateUserCommandVM, AuthenticateUserCommand>(vm);
        }
    }
}