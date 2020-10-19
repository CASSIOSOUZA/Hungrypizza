using HungryPizza.WebAPI.Core.ViewModels.Queries.Request;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Core.SwaggerDocs.Examples.Request
{
    public class RequestGetQueryEx : IExamplesProvider<RequestGetQueryVM>
    {
        /// <summary>
        /// Gets the examples.
        /// </summary>
        /// <returns></returns>
        public RequestGetQueryVM GetExamples()
        {
            return new RequestGetQueryVM();
        }
    }
}