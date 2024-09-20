using eAppoinmentServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Users.DeleteUserById;

public sealed record DeleteUserByIdCommand(Guid Id) : IRequest<Result<string>>;

