using eAppoinmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Patients.GetAllPatient;

public sealed record GetAllPatientQuery:IRequest<Result<List<Patient>>>;
