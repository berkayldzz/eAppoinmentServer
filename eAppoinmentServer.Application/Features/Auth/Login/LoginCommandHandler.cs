using eAppoinmentServer.Application.Services;
using eAppoinmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Auth.Login;


// User ile ilgili işlemlerimi yapabilmek için Identity kütüphanesinden gelen UserManager classına ihtiyacım var.Bu class sayesinde user ile ilgili tüm işlemlerimi yapabilirim.

// .Net 8 ile gelen primary constructor özelliği parantezin içinde yazdım.ctor olarak orayı kullanabiliyoruz.
internal sealed class LoginCommandHandler(UserManager<AppUser> userManager,IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // requestten gelen username ve emaile göre kullanıcım olup olmadığını tespit ediyorum.
        AppUser? appUser =
           await userManager.Users.FirstOrDefaultAsync(p =>
           p.UserName == request.UserNameOrEmail ||
           p.Email == request.UserNameOrEmail, cancellationToken);

        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        // kullanıcı varsa şifre kontrolü yapıyorum

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (!isPasswordCorrect)
        {
            return Result<LoginCommandResponse>.Failure("Password is wrong");
        }

        string token = await jwtProvider.CreateTokenAsync(appUser);
        LoginCommandResponse response = new(token);

        return Result<LoginCommandResponse>.Succeed(response);

    }
}