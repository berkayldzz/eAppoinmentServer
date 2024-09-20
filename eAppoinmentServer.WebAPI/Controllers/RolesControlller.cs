using eAppoinmentServer.Application.Features.Roles.RoleSync;
using eAppoinmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAppoinmentServer.WebAPI.Controllers;

[AllowAnonymous]
public sealed class RolesControlller : ApiController
{
    public RolesControlller(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]

    public async Task<IActionResult> Sync(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
