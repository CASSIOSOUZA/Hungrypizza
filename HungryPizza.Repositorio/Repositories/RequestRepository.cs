using HungryPizza.Repositorio.Context;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Entities.History;
using HungryPizza.Servico.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Repositorio.Repositories
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        private readonly IPizzaRepository _pizzaRepo;

        public RequestRepository(SQLContext ctx, IPizzaRepository p) : base(ctx)
        {
            _pizzaRepo = p;
        }

        public async Task<bool> IdRequestExists(int idRequest)
        {
            return await Ctx.Request.AnyAsync(a => a.Id == idRequest && a.Active);
        }

        public async Task<bool> UidExists(Guid uid)
        {
            return await Ctx.Request.AnyAsync(a => a.Uid == uid && a.Active);
        }

        public async Task<Request> CreateRequest(Request request)
        {
            // CREATES REQUEST
            int quantity = request.RequestPizzas.Sum(s => s.Quantity);
            decimal total = await GetTotal(request);
            var newRequest = new Request(0, DateTime.Now, Guid.NewGuid(), quantity, total, request.IdCustomer, request.Address, true);
            await Ctx.Request.AddAsync(newRequest);
            await Ctx.SaveChangesAsync();

            // CREATES REQUESTED PIZZAS
            var newRequestPizzas = request.RequestPizzas
                .Select(s => new RequestPizza(0, newRequest.Id, s.IdPizzaFirstHalf, s.IdPizzaSecondHalf, s.Quantity, s.Total, true))
                .ToList();
            await Ctx.RequestPizza.AddRangeAsync(newRequestPizzas);
            await Ctx.SaveChangesAsync();

            // INSERT NEW REQUESTED PIZZAS IN NEW REQUEST
            newRequest.AddRequestPizzaRange(newRequestPizzas);

            return newRequest;
        }

        private async Task<decimal> GetTotal(Request request)
        {
            decimal total = 0;
            foreach (var rp in request.RequestPizzas)
            {
                var pizzaFirstHalf = await Ctx.Pizza.AsNoTracking().FirstOrDefaultAsync(f => f.Id == rp.IdPizzaFirstHalf);
                var pizzaSecondHalf = await Ctx.Pizza.AsNoTracking().FirstOrDefaultAsync(f => f.Id == rp.IdPizzaSecondHalf);
                decimal pizzaTotal = 0;

                if (pizzaFirstHalf.Id == pizzaSecondHalf.Id)
                {
                    pizzaTotal = (pizzaFirstHalf.Price * rp.Quantity);
                }
                else
                {
                    var valueOne = (pizzaFirstHalf.Price / 2) * rp.Quantity;
                    var valueTwo = (pizzaSecondHalf.Price / 2) * rp.Quantity;
                    pizzaTotal = valueOne + valueTwo;
                }

                rp.SetTotal(pizzaTotal);
                total += pizzaTotal;
            }

            return total;
        }

        public async Task<IEnumerable<Request>> Get(Expression<Func<Request, bool>> expression)
        {
            var requests = await Ctx.Request
                    .AsNoTracking()
                    .Where(expression)
                    .OrderBy(o => o.Id)
                    .ToListAsync();
            requests
            .ForEach(e =>
            {
                e.AddRequestPizzaRange(Ctx.RequestPizza.Where(w => w.IdRequest == e.Id).ToList());
            });
            return requests;
        }

        public async Task<IEnumerable<RequestHistory>> GetHistoryByIdCustomer(int idCustomer)
        {
            var requests = await Ctx.Request
                    .Join(Ctx.Customer,
                        a => a.IdCustomer,
                        b => b.Id,
                        (a, b) => new { a, b }
                    )
                    .AsNoTracking()
                    .Select(s => s.a)
                    .Where(w => w.IdCustomer == idCustomer)
                    .OrderBy(o => o.Id)
                    .ToListAsync();

            var requestHistory = new List<RequestHistory>();
            requests
                .ForEach(e =>
                {
                    var requestHistoryPizzas = new List<RequestHistoryPizza>();
                    var requestPizzas = Ctx.RequestPizza.Where(w => w.IdRequest == e.Id).OrderBy(o => o.Id).ToList();
                    requestPizzas.ForEach(e =>
                    {
                        var firstHalfPizza = _pizzaRepo.GetPizza(e.IdPizzaFirstHalf).Result;
                        var secondHalfPizza = _pizzaRepo.GetPizza(e.IdPizzaSecondHalf).Result;
                        var requestHistoryPizza = new RequestHistoryPizza(
                            new RequestHistoryPizzaInfo(firstHalfPizza.Name, firstHalfPizza.Price),
                            new RequestHistoryPizzaInfo(secondHalfPizza.Name, secondHalfPizza.Price),
                            e.Quantity,
                            e.Total);
                        requestHistoryPizzas.Add(requestHistoryPizza);
                    });
                    requestHistory.Add(new RequestHistory(e.Uid, e.CreatedAt, requestHistoryPizzas, e.Quantity, e.Total));
                });
            return requestHistory;
        }
    }
}