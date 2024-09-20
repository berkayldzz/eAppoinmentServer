using MediatR;
using System.Threading;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Users.GetAllUsers;



public sealed record GetAllUsersQuery : IRequest<Result<List<GetAllUsersQueryResponse>>>;
