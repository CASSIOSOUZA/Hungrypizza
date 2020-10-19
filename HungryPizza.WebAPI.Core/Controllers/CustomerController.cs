using AutoMapper;
using HungryPizza.Servico.Commands.Customer;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Customer;
using HungryPizza.WebAPI.Core.ViewModels.Commands.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="mediatR">The mediat r.</param>
        /// <param name="mapper">The mapper.</param>
        public CustomerController(IMediator mediatR, IMapper mapper) : base(mediatR, mapper)
        {
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateCustomerCommandVM), typeof(CreateCustomerCommandEx))]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandVM vm)
        {
            return await Send<CreateCustomerCommandVM, CreateCustomerCommand>(vm);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerRequestExample(typeof(UpdateCustomerCommandVM), typeof(UpdateCustomerCommandEx))]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommandVM vm)
        {
            return await Send<UpdateCustomerCommandVM, UpdateCustomerCommand>(vm);
        }
    }
}