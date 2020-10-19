using AutoMapper;
using HungryPizza.Compartilhado.CommandQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Core.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediatR">The mediat r.</param>
        /// <param name="mapper">The mapper.</param>
        public BaseController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        /// <summary>
        /// Sends the specified vm.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TCommandQuery">The type of the command query.</typeparam>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        protected async Task<IActionResult> Send<TViewModel, TCommandQuery>(TViewModel vm) where TCommandQuery : CommandQuery
        {
            try
            {
                var request = _mapper.Map<TCommandQuery>(vm);
                var result = (CommandQuery)await _mediatR.Send(request, new CancellationToken());
                if (!result.Valid)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sends the specified request.
        /// </summary>
        /// <typeparam name="ICommandQuery">The type of the command query.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        protected async Task<IActionResult> Send<ICommandQuery>(ICommandQuery request)
        {
            try
            {
                var result = (CommandQuery)await _mediatR.Send(request, new CancellationToken());
                if (result != null && !result.Valid)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result?.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}