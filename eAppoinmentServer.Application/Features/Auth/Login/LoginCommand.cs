using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Auth.Login;

// record: Bir nesne oluşturulduğunda aldığı parametreler değiştirilemez.

// Kullanıcı girişi için gereken değerlerimi isteyeceğim.
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password): IRequest<Result<LoginCommandResponse>>;


// Result objem geriye LoginCommandResponse dönecek.
