using eAppoinmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Users.DeleteUserById;

internal sealed class DeleteUserByIdCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());

        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        return "User delete is succesful.";

    }
}

