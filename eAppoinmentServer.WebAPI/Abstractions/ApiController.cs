using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAppoinmentServer.WebAPI.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
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
