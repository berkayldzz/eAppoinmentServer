using eAppoinmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetAllDoctorsByDepartment;


// Departmana göre doktor listesini almak istiyoruz.
public sealed record GetAllDoctorsByDepartmentQuery(int DepartmentValue) : IRequest<Result<List<Doctor>>>;
