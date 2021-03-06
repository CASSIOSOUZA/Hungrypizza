using HungryPizza.Servico.Commands.Customer;
using HungryPizza.Servico.Handlers.Commands;
using HungryPizza.Servico.Interfaces.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Commands.Customer
{
    public class UpdateCustomerCommandTests : BaseTests
    {
        private readonly Mock<ICustomerRepository> _customerRepo;
        private readonly Mock<IUserRepository> _userRepo;

        public UpdateCustomerCommandTests()
        {
            _customerRepo = new Mock<ICustomerRepository>();
            _userRepo = new Mock<IUserRepository>();
        }

        [Fact]
        public void ErrorUpdateCustomerIdCustomer()
        {
            var command = new UpdateCustomerCommand(0, null, null, null, null, false, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1009));
        }

        [Theory]
        [InlineData(null, 1000)]
        [InlineData("ab", 1001)]
        public void ErrorUpdateCustomerName(string name, int errorCode)
        {
            var command = new UpdateCustomerCommand(0, name, null, null, null, false, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Theory]
        [InlineData(null, 1002)]
        [InlineData("ab", 1003)]
        [InlineData("cassioguilhermy1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000w@a.a", 1004)]
        public void ErrorUpdateCustomerEmail(string email, int errorCode)
        {
            var command = new UpdateCustomerCommand(0, null, email, null, null, false, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Theory]
        [InlineData(null, 1005)]
        [InlineData("abc", 1006)]
        [InlineData("longstring1000000000000000", 1006)]
        public void ErrorUpdateCustomerPassword(string password, int errorCode)
        {
            var command = new UpdateCustomerCommand(0, null, null, password, null, false, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Theory]
        [InlineData(null, 1007)]
        [InlineData("ab", 1008)]
        [InlineData("cassioguilhermy1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000w", 1008)]
        public void ErrorUpdateCustomerAddress(string address, int errorCode)
        {
            var command = new UpdateCustomerCommand(0, null, null, null, address, false, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Fact]
        public void ErrorUpdateCustomerIdCustomerNotExists()
        {
            _customerRepo.Setup(s => s.IdCustomerExists(It.IsAny<int>())).Returns(Task.FromResult(false));

            var command = new UpdateCustomerCommand(1, "Cassio Guilhermy", "ca@a.a", "cass123", "Gyn", true, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2005));
        }

        [Fact]
        public void ErrorUpdateCustomerIdUserNotExists()
        {
            _customerRepo.Setup(s => s.IdCustomerExists(It.IsAny<int>())).Returns(Task.FromResult(true));
            var customer = new Servico.Entities.Customer(1, 1, "MY NAME", "MY ADDRESS");
            _customerRepo.Setup(s => s.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult(customer));
            _userRepo.Setup((s) => s.IdUserExists(It.IsAny<int>())).Returns(Task.FromResult(false));

            var command = new UpdateCustomerCommand(1, "Cassio Guilhermy", "ca@a.a", "cass123", "Gyn", true, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2000));
        }

        [Fact]
        public void ErrorUpdateCustomerEmailExistsDifferentUser()
        {
            _customerRepo.Setup(s => s.IdCustomerExists(It.IsAny<int>())).Returns(Task.FromResult(true));
            var customer = new Servico.Entities.Customer(1, 1, "MY NAME", "MY ADDRESS");
            _customerRepo.Setup(s => s.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult(customer));
            _userRepo.Setup((s) => s.EmailExistsDifferentUser(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var command = new UpdateCustomerCommand(1, "Cassio Guilhermy", "ca@a.a", "cass123", "Gyn", true, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2003));
        }
    }
}