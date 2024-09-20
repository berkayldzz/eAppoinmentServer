using MediatR;
using Microsoft.VisualBasic;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Roles.RoleSync;

public sealed record RoleSyncCommand() : IRequest<Result<string>>;
