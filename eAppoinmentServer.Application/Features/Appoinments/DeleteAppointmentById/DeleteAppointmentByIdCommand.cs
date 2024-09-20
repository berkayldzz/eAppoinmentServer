using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.DeleteAppointmentById;

public sealed record DeleteAppointmentByIdCommand(Guid Id):IRequest<Result<string>>;

