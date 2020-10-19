namespace HungryPizza.Servico.Entities.History
{
    public class RequestHistoryPizzaInfo
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public RequestHistoryPizzaInfo(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}