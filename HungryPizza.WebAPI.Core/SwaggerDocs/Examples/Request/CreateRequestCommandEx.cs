using HungryPizza.WebAPI.Core.ViewModels.Commands.Request;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Request
{
    public class CreateRequestCommandEx : IExamplesProvider<CreateRequestCommandVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public CreateRequestCommandVM GetExamples()
        {
            var pizzas = new List<RequestPizzaCommandVM>
            {
                new RequestPizzaCommandVM { IdPizzaFirstHalf = 1, IdPizzaSecondHalf = 1, Quantity = 1 },
                new RequestPizzaCommandVM { IdPizzaFirstHalf = 2, IdPizzaSecondHalf = 3, Quantity = 1 }
            };
            return new CreateRequestCommandVM
            {
                Address = "MY ADDRESS",
                Pizzas = pizzas
            };
        }
    }
}