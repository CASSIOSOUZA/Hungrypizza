using HungryPizza.Servico.Entities;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> IdCustomerExists(int idCustomer);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> GetCustomer(int idCustomer);

        Task UpdateCustomer(Customer customer);
    }
}