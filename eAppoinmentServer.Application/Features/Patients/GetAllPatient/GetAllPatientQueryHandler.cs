using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Patients.GetAllPatient;

internal sealed class GetAllPatientQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patient = await patientRepository.GetAll().OrderBy(p=>p.FirstName).ToListAsync(cancellationToken);

        return patient;
    }
}
