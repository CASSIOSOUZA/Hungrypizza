using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Validations.Queries.Request;

namespace HungryPizza.Servico.Queries.Request
{
    public class RequestHistoryQuery : CommandQuery
    {
        public int IdCustomer { get; private set; }

        public RequestHistoryQuery(
            int idCustomer,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
        }

        public bool IsValid()
        {
            Validate(this, new RequestHistoryQueryValidation());
            return Valid;
        }
    }
}