using AutoMapper;
using HungryPizza.Servico.Queries.Pizza;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Pizza;
using HungryPizza.WebAPI.Core.ViewModels.Queries.Pizza;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PizzaController"/> class.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="mp">The mp.</param>
        public PizzaController(IMediator m, IMapper mp) : base(m, mp) { }

        /// <summary>
        /// Gets the pizza.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerRequestExample(typeof(PizzaGetQueryVM), typeof(PizzaGetQueryEx))]
        public async Task<IActionResult> GetPizza([FromQuery] PizzaGetQueryVM vm)
        {
            return await Send<PizzaGetQueryVM, PizzaGetQuery>(vm);
        }
    }
}