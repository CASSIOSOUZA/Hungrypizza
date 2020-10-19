namespace HungryPizza.Servico.Commands.Request
{
    public class RequestPizzaCommand
    {
        public int IdPizzaFirstHalf { get; private set; }
        public int IdPizzaSecondHalf { get; private set; }
        public int Quantity { get; private set; }

        public RequestPizzaCommand(int idPizzaFirstHalf, int idPizzaSecondHalf, int quantity)
        {
            IdPizzaFirstHalf = idPizzaFirstHalf;
            IdPizzaSecondHalf = idPizzaSecondHalf;
            Quantity = quantity;
        }
    }
}