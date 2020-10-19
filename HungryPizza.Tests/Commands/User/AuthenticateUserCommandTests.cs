using HungryPizza.Servico.Commands.User;
using HungryPizza.Servico.Handlers.Commands;
using HungryPizza.Servico.Interfaces.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Commands.User
{
    public class AuthenticateUserCommandTests : BaseTests
    {
        private readonly Mock<IUserRepository> _userRepo;

        public AuthenticateUserCommandTests()
        {
            _userRepo = new Mock<IUserRepository>();
        }

        [Theory]
        [InlineData(null, 1002)]
        [InlineData("ab", 1003)]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvz@a.a", 1004)]
        public void ErrorAuthenticateUserEmail(string email, int errorCode)
        {
            var command = new AuthenticateUserCommand(email, null, _appSettings);
            var commandResult = new UserCommandHandler(_mapper, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Theory]
        [InlineData(null, 1005)]
        [InlineData("abc", 1006)]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 1006)]
        public void ErrorAuthenticateUserPassword(string password, int errorCode)
        {
            var command = new AuthenticateUserCommand(null, password, _appSettings);
            var commandResult = new UserCommandHandler(_mapper, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Fact]
        public void ErrorAuthenticateUserEmailOrPasswordInvalid()
        {
            Servico.Entities.Customer customer = null;
            _userRepo.Setup((s) => s.Authenticate(It.IsAny<Servico.Entities.User>())).Returns(Task.FromResult(customer));

            var command = new AuthenticateUserCommand("a@a.a", "abc123", _appSettings);
            var commandResult = new UserCommandHandler(_mapper, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2004));
        }
    }
}