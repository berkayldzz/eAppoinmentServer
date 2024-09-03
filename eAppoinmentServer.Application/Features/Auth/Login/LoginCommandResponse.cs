namespace eAppoinmentServer.Application.Features.Auth.Login;

// Geriye bir token döneceğiz.
public sealed record LoginCommandResponse(
    string token);
