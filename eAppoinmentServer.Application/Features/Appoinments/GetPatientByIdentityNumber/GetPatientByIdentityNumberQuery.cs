using eAppoinmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetPatientByIdentityNumber;

public sealed record GetPatientByIdentityNumberQuery(
    string IdentityNumber) : IRequest<Result<Patient>>;
