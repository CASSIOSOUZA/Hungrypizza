using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using System;
using System.Linq.Expressions;

namespace HungryPizza.Servico.Queries.Request
{
    public class RequestGetQuery : CommandQuery
    {
        public int? IdCustomer { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid Uid { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public string Address { get; private set; }

        public RequestGetQuery(int? idCustomer, DateTime createdAt, Guid uid, int quantity, decimal total, string address,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
            CreatedAt = createdAt;
            Uid = uid;
            Quantity = quantity;
            Total = total;
            Address = address;
        }

        public Expression<Func<Entities.Request, bool>> Get()
        {
            return r => (IdCustomer == null || IdCustomer == 0 || r.IdCustomer == IdCustomer)
                        &&
                        (CreatedAt.Equals(default) || r.CreatedAt.Date.Equals(CreatedAt.Date))
                        &&
                        (string.IsNullOrEmpty(Address) || r.Address.ToLower().Contains(Address.ToLower().Trim()))
                        &&
                        (Quantity == 0 || r.Quantity == Quantity)
                        &&
                        (Total == 0 || r.Total == Total)
                        &&
                        (Uid.Equals(Guid.Empty) || r.Uid.Equals(Uid))
                        &&
                        r.Active;
        }
    }
}