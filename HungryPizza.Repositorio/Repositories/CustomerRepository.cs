using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Repositorio.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SQLContext ctx) : base(ctx)
        {
        }

        public async Task<bool> IdCustomerExists(int idCustomer)
        {
            return await Ctx.Customer
                .Join(Ctx.User,
                    a => a.IdUser,
                    b => b.Id,
                    (a, b) => new { a, b }
                )
                .AnyAsync(x => x.a.Id == idCustomer && x.b.Active);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            Ctx.Customer.Add(customer);
            await Ctx.SaveChangesAsync();

            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            Ctx.Customer.Update(customer);
            await Ctx.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int idCustomer)
        {
            return await Ctx.Customer.AsNoTracking().FirstOrDefaultAsync(f => f.Id == idCustomer);
        }
    }
}