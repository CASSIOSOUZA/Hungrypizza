using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HungryPizza.Repositorio.Repositories
{
    public class RequestPizzaRepository : BaseRepository<RequestPizza>, IRequestPizzaRepository
    {
        public RequestPizzaRepository(SQLContext ctx) : base(ctx)
        {
        }

        public async Task<bool> IdPizzaExists(int idPizza)
        {
            return await Ctx.Pizza.AnyAsync(a => a.Id == idPizza && a.Active);
        }
    }
}