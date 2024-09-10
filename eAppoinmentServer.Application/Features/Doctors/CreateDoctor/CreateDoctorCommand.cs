using eAppoinmentServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Doctors.CreateDoctor;

public sealed record CreateDoctorCommand(string FirstName,string LastName,int DepartmentValue):IRequest<Result<string>>;
