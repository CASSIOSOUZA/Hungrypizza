using AutoMapper;
using HungryPizza.Compartilhado.Interfaces;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Queries.Request;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Handlers.Queries
{
    public class RequestQueryHandler : //CommandQueryHandler,
        IRequestHandler<RequestGetQuery, ICommandQuery>,
        IRequestHandler<RequestHistoryQuery, ICommandQuery>
    {
        private readonly IRequestRepository _repo;

        public RequestQueryHandler(IMapper m, IRequestRepository repo)//:base(m)
        {
            _repo = repo;
        }

        public async Task<ICommandQuery> Handle(RequestGetQuery query, CancellationToken cancellationToken)
        {
            var requests = await _repo.Get(query.Get());
            if (requests.ToList().Count == 0)
            {
                query.AddError(2011);
            }
            else
            {
                query.SetData(requests);
            }
            return query;
        }

        public async Task<ICommandQuery> Handle(RequestHistoryQuery query, CancellationToken cancellationToken)
        {
            // VALIDATE QUERY
            if (!query.IsValid())
                return query;

            // GET REQUEST HISTORY
            var requests = await _repo.GetHistoryByIdCustomer(query.IdCustomer);
            if (requests.ToList().Count == 0)
            {
                query.AddError(2012);
            }
            else
            {
                query.SetData(requests);
            }
            return query;
        }
    }
}