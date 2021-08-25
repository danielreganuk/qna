using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Qna.Api.Shared;
using System;
using System.Threading.Tasks;

namespace Qna.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected async Task<ActionResult<ApiResponse>> GenerateResponse(object data, int count = 0)
        {
            var response = new ApiResponse(data, count);

            if (data == null)
            {
                return Accepted(response);
            }
            if (data.GetType() == typeof(Exception))
            {
                return StatusCode(500, response);
            }

            if (response.DataCount == 0) response.DataCount = 1; // TODO: Make this elegant. Hack fix.
            return Ok(response);
        }
    }
}