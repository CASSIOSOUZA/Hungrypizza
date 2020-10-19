using AutoMapper;
using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Queries.Pizza;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Handlers.Queries
{
    public class PizzaQueryHandler : CommandQueryHandler,
        IRequestHandler<PizzaGetQuery, ICommandQuery>
    {
        private readonly IPizzaRepository _repo;

        public PizzaQueryHandler(IMapper m, IPizzaRepository repo) : base(m)
        {
            _repo = repo;
        }

        public async Task<ICommandQuery> Handle(PizzaGetQuery query, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.Get(query.Get());
            if (pizzas.ToList().Count == 0)
            {
                query.AddError(2010);
            }
            else
            {
                query.SetData(pizzas);
            }
            return query;
        }
    }
}