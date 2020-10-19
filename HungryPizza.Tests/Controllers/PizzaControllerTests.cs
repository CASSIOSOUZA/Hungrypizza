using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Queries.Pizza;
using HungryPizza.WebAPI.Core.Controllers;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Pizza;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class PizzaControllerTests : BaseTests
    {
        [Fact]
        public void SuccessGetPizzas()
        {
            var vm = new PizzaGetQueryEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var pizza = new Pizza(1, "SOME PIZZA", 50, true);
            var pizzas = new List<Pizza>();
            pizzas.Add(pizza);
            commandQuery.SetData(pizzas);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<PizzaGetQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new PizzaController(mediator.Object, _mapper).GetPizza(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }

      
    }
}