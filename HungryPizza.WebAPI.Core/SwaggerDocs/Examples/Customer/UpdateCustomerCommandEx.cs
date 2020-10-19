using HungryPizza.WebAPI.Core.ViewModels.Commands.Customer;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Customer
{
    public class UpdateCustomerCommandEx : IExamplesProvider<UpdateCustomerCommandVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public UpdateCustomerCommandVM GetExamples()
        {
            return new UpdateCustomerCommandVM
            {
                IdCustomer = 1,
                Name = "MY NEW NAME",
                Email = "my@email.com",
                Password = "MY_NEW_PASSWORD",
                Address = "MY NEW ADDRESS",
                Active = true
            };
        }
    }
}