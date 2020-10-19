using FluentValidation;
using HungryPizza.Servico.Queries.Request;

namespace HungryPizza.Servico.Validations.Queries.Request
{
    public class RequestHistoryQueryValidation : AbstractValidator<RequestHistoryQuery>
    {
        public RequestHistoryQueryValidation()
        {
            RuleFor(x => x.IdCustomer)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode("1009");
        }
    }
}