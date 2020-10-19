using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Commands.User;
using HungryPizza.Servico.Entities;
using HungryPizza.WebAPI.Core.Controllers;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class UserControllerTests : BaseTests
    {
        [Fact]
        public void SuccessAuthenticateUser()
        {
            var vm = new AuthenticateUserCommandEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var customer = new Customer(1, 1, "MY NAME", "MY ADDRESS");
            //customer.SetUser(new User(1, vm.Email, vm.Password, true));
            commandQuery.SetData(customer);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<AuthenticateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new UserController(mediator.Object, _mapper).AuthenticateUser(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}