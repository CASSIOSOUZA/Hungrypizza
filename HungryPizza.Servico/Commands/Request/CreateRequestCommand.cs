using HungryPizza.Compartilhado.CommandQuery;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Interfaces.Repositories;
using HungryPizza.Servico.Validations.Commands.Request;
using HungryPizza.Servico.Validations.Repositories.Request;
using System.Collections.Generic;

namespace HungryPizza.Servico.Commands.Request
{
    public class CreateRequestCommand : CommandQuery
    {
        public CreateRequestCommand(
            int? idCustomer, string address, List<RequestPizzaCommand> pizzas,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
            Address = address;
            Pizzas = pizzas ?? new List<RequestPizzaCommand>();
        }

        public int? IdCustomer { get; private set; }
        public string Address { get; private set; }
        public List<RequestPizzaCommand> Pizzas { get; private set; }

        public bool IsValid()
        {
            Validate(this, new CreateRequestCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.Request request, IPizzaRepository pizzaRepository, ICustomerRepository customerRepository)
        {
            foreach (var rp in request.RequestPizzas)
            {
                Validate(rp, new CreateRequestPizzaRepositoryValidation(pizzaRepository));
                if (!Valid)
                    return false;
            }

            if (request.IdCustomer == null) return Valid;
            var customer = new Entities.Customer((int)request.IdCustomer, 0, null, null);
            Validate(customer, new CreateRequestCustomerRepositoryValidation(customerRepository));
            return Valid;
        }
    }
}