using HungryPizza.WebAPI.Core.ViewModels.Queries.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Pizza
{
    public class PizzaGetQueryEx : IExamplesProvider<PizzaGetQueryVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public PizzaGetQueryVM GetExamples()
        {
            return new PizzaGetQueryVM();
        }
    }
}