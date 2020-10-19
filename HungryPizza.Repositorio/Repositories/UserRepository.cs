using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Repositorio.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SQLContext ctx) : base(ctx)
        {
        }

        public async Task<bool> EmailExists(string email)
        {
            return await Ctx.User.AsNoTracking().AnyAsync(a => a.Email.ToUpper().Equals(email.ToUpper()));
        }

        public async Task<bool> EmailExistsDifferentUser(int idUser, string email)
        {
            return await Ctx.User.AnyAsync(a => a.Id != idUser && a.Email.ToUpper().Equals(email.ToUpper()));
        }

        public async Task<bool> IdUserExists(int idUser)
        {
            return await Ctx.User.AnyAsync(a => a.Id == idUser && a.Active);
        }

        public async Task<User> CreateUser(User user)
        {
            await Ctx.User.AddAsync(user);
            await Ctx.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUser(User user)
        {
            Ctx.User.Update(user);
            await Ctx.SaveChangesAsync();
        }

        public async Task<Customer> Authenticate(User user)
        {
            var oldUser = await Ctx.Customer
                                .Join(Ctx.User,
                                    a => a.IdUser,
                                    b => b.Id,
                                    (a, b) => new { a, b }
                                )
                                .AsNoTracking()
                                .Where(f =>
                                    f.b.Email.ToUpper().Equals(user.Email.ToUpper().Trim())
                                    && f.b.Password.Equals(user.Password)
                                    && f.b.Active)
                                .Select(s => s.a)
                                .FirstOrDefaultAsync();
            return oldUser;
        }
    }
}