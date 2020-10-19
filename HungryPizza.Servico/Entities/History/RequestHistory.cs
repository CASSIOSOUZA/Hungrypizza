using System;
using System.Collections.Generic;

namespace HungryPizza.Servico.Entities.History
{
    public class RequestHistory
    {
        public Guid Uid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<RequestHistoryPizza> Pizzas { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }

        public RequestHistory(Guid uid, DateTime createdAt, List<RequestHistoryPizza> pizzas, int quantity, decimal total)
        {
            Uid = uid;
            CreatedAt = createdAt;
            Pizzas = pizzas;
            Quantity = quantity;
            Total = total;
        }
    }
}