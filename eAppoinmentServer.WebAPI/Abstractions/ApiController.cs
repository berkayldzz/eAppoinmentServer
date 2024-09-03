using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppoinmentServer.WebAPI.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

        // Base api controller yapımız.

        public readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
