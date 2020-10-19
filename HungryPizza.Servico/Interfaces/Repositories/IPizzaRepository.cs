using HungryPizza.Servico.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Interfaces.Repositories
{
    public interface IPizzaRepository : IBaseRepository<Pizza>
    {
        Task<bool> IdPizzaExists(int idPizza);

        Task<IEnumerable<Pizza>> Get(Expression<Func<Pizza, bool>> expression);

        Task<Pizza> GetPizza(int idPizza);
    }
}