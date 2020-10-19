using HungryPizza.Servico.Entities;
using System.Threading.Tasks;

namespace HungryPizza.Servico.Interfaces.Repositories
{
    public interface IRequestPizzaRepository : IBaseRepository<RequestPizza>
    {
        Task<bool> IdPizzaExists(int idPizza);
    }
}