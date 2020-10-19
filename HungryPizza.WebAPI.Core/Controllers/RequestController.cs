using AutoMapper;
using HungryPizza.Servico.Commands.Request;
using HungryPizza.Servico.Queries.Request;
using HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Request;
using HungryPizza.WebAPI.Core.ViewModels.Commands.Request;
using HungryPizza.WebAPI.Core.ViewModels.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestController"/> class.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="mp">The mp.</param>
        public RequestController(IMediator m, IMapper mp) : base(m, mp) { }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateRequestCommandVM), typeof(CreateRequestCommandEx))]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestCommandVM vm)
        {
            return await Send<CreateRequestCommandVM, CreateRequestCommand>(vm);
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerRequestExample(typeof(RequestGetQueryVM), typeof(RequestGetQueryEx))]
        public async Task<IActionResult> GetRequest([FromQuery] RequestGetQueryVM vm)
        {
            return await Send<RequestGetQueryVM, RequestGetQuery>(vm);
        }

        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="idCustomer">The identifier customer.</param>
        /// <returns></returns>
        [HttpGet("{idCustomer}")]
        [SwaggerRequestExample(typeof(RequestGetQueryVM), typeof(RequestGetQueryEx))]
        public async Task<IActionResult> GetHistory([FromRoute] int idCustomer)
        {
            var vm = new RequestHistoryQueryVM { IdCustomer = idCustomer };
            return await Send<RequestHistoryQueryVM, RequestHistoryQuery>(vm);
        }
    }
}