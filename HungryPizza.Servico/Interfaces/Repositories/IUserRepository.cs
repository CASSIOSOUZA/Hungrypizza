using HungryPizza.Servico.Entities;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> IdUserExists(int idUser);

        Task<bool> EmailExists(string email);

        Task<bool> EmailExistsDifferentUser(int idUser, string email);

        Task<User> CreateUser(User user);

        Task UpdateUser(User user);

        Task<Customer> Authenticate(User user);
    }
}