using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Patients.DeletePatientById;

public sealed record DeletePatientByIdCommand(Guid Id) : IRequest<Result<string>>;
