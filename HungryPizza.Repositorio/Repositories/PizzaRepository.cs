using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Repositorio.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(SQLContext ctx) : base(ctx)
        {
        }

        public async Task<bool> IdPizzaExists(int idPizza)
        {
            return await Ctx.Pizza.AnyAsync(a => a.Id == idPizza && a.Active);
        }

        public async Task<IEnumerable<Pizza>> Get(Expression<Func<Pizza, bool>> expression)
        {
            return await Ctx.Pizza.AsNoTracking().Where(expression).OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<Pizza> GetPizza(int idPizza)
        {
            return await Ctx.Pizza.AsNoTracking().FirstOrDefaultAsync(f => f.Id == idPizza && f.Active);
        }
    }
}