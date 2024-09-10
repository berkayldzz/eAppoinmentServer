using eAppoinmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Doctors.GetAllDoctor;

public sealed record class GetAllDoctorQuery():IRequest<Result<List<Doctor>>>;
