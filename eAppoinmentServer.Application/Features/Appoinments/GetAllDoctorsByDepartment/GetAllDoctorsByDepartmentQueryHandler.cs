using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetAllDoctorsByDepartment;

//internal sealed class GetAllDoctorsByDepartmentQueryHandler(IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsByDepartmentQuery, Result<List<Doctor>>>
//{
//    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
//    {
        

//        List<Doctor> doctors = await doctorRepository.Where(p => p.Department == request.DepartmentValue).OrderBy(p => p.FirstName)
//            .ToListAsync(cancellationToken);

//        return doctors;
//    }
//}

internal sealed class GetAllDoctorsByDepartmentQueryHandler(
    IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsByDepartmentQuery, Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
    {
        // departmana ait doktorları listeliyoruz.

        List<Doctor> doctors =
            await doctorRepository
            .Where(p => p.Department == request.DepartmentValue)
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);

        return doctors;
    }
}
