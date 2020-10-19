using HungryPizza.WebAPI.Core.ViewModels.Commands.Customer;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Customer
{
    public class CreateCustomerCommandEx : IExamplesProvider<CreateCustomerCommandVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public CreateCustomerCommandVM GetExamples()
        {
            return new CreateCustomerCommandVM
            {
                Name = "MY NAME",
                Email = "my@email.com",
                Password = "MY_PASSWORD",
                Address = "MY ADDRESS"
            };
        }
    }
}