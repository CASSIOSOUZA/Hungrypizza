using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Commands.Request;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Entities.History;
using HungryPizza.Servico.Queries.Request;
using HungryPizza.WebAPI.Core.Controllers;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class RequestControllerTests : BaseTests
    {
        [Fact]
        public void SuccessCreateRequest()
        {
            var vm = new CreateRequestCommandEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var request = new Request(1, DateTime.Now, Guid.NewGuid(), 1, 50, 1, "MY ADDRESS", true);
            request.AddRequestPizza(new RequestPizza(1, 1, 1, 1, 1, 10, true));
            commandQuery.SetData(request);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<CreateRequestCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new RequestController(mediator.Object, _mapper).CreateRequest(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void SuccessGetRequests()
        {
            var vm = new RequestGetQueryEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var request = new Request(1, DateTime.Now, Guid.NewGuid(), 1, 50, 1, "MY ADDRESS", true);
            request.AddRequestPizza(new RequestPizza(1, 1, 1, 1, 1, 10, true));
            commandQuery.SetData(request);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<RequestGetQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new RequestController(mediator.Object, _mapper).GetRequest(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void SuccessRequestHistory()
        {
            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var requests = new List<RequestHistoryPizza>();
            var pizza1 = new RequestHistoryPizzaInfo("PIZZA FIRST HALF", 25);
            var pizza2 = new RequestHistoryPizzaInfo("PIZZA SECOND HALF", 35);
            requests.Add(new RequestHistoryPizza(pizza1, pizza2, 5, 35));
            commandQuery.SetData(requests);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<RequestHistoryQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new RequestController(mediator.Object, _mapper).GetHistory(1);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void SuccessPizzasCalculatingValuesPizza()
        {
            var vm = new RequestGetQueryEx().GetExamples();

            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var request = new Request(1, DateTime.Now, Guid.NewGuid(), 1, 50, 1, "MY ADDRESS", true);
            request.AddRequestPizza(new RequestPizza(1, 1, 1, 1, 1, 10, true));
            commandQuery.SetData(request);

            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                    s.Send(It.IsAny<RequestGetQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));

            var result = new RequestController(mediator.Object, _mapper).GetRequest(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}