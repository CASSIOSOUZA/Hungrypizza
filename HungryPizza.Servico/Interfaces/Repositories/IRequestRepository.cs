using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Entities.History;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Interfaces.Repositories
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        Task<bool> IdRequestExists(int idRequest);

        Task<bool> UidExists(Guid uid);

        Task<Request> CreateRequest(Request request);

        Task<IEnumerable<Request>> Get(Expression<Func<Request, bool>> expression);

        Task<IEnumerable<RequestHistory>> GetHistoryByIdCustomer(int idCustomer);
    }
}