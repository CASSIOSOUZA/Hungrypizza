using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Commands.Customer;
using HungryPizza.Servico.Entities;
using HungryPizza.WebAPI.Core.Controllers;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class CustomerControllerTests : BaseTests
    {
        [Fact]
        public void SuccessCreateCustomer()
        {
            var vm = new CreateCustomerCommandEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var customer = new Customer(1, 1, vm.Name, vm.Address);
          
            commandQuery.SetData(customer);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new CustomerController(mediator.Object, _mapper).CreateCustomer(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void SuccessUpdateCustomer()
        {
            var vm = new UpdateCustomerCommandEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<UpdateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new CustomerController(mediator.Object, _mapper).UpdateCustomer(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}