using eAppoinmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Users.GetAllRolesForUsers;

public sealed record  GetAllRolesForUsersQuery:IRequest<Result<List<AppRole>>>;
