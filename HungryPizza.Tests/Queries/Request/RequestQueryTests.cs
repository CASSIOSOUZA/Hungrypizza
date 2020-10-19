using HungryPizza.Servico.Entities.History;
using HungryPizza.Servico.Handlers.Queries;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Queries.Request;
using HungryPizza.Tests;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryRequest.Tests.Queries.Request
{
    public class RequestQueryTests : BaseTests
    {
        private readonly Mock<IRequestRepository> _repo;

        public RequestQueryTests()
        {
            _repo = new Mock<IRequestRepository>();
        }

        [Fact]
        public void ErrorRequestHistoryIdCustomerNotInformed()
        {
            var query = new RequestHistoryQuery(0, _appSettings);
            var commandResult = new RequestQueryHandler(_mapper, _repo.Object)
               .Handle(query, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1009));
        }

        [Fact]
        public void ErrorRequestHistoryNotFound()
        {
            IEnumerable<RequestHistory> requestHistories = new List<RequestHistory>();
            _repo.Setup((s) => s.GetHistoryByIdCustomer(It.IsAny<int>()))
                .Returns(Task.FromResult(requestHistories));

            var query = new RequestHistoryQuery(1, _appSettings);
            var commandResult = new RequestQueryHandler(_mapper, _repo.Object)
               .Handle(query, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2012));
        }
    }
}