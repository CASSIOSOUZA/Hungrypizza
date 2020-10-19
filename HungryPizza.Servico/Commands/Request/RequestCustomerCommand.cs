namespace HungryPizza.Servico.Commands.Request
{
    public class RequestCustomerCommand
    {
        public int? IdCustomer { get; private set; }
        public string Address { get; private set; }

        public RequestCustomerCommand(int? idCustomer, string address)
        {
            IdCustomer = idCustomer;
            Address = address;
        }
    }
}