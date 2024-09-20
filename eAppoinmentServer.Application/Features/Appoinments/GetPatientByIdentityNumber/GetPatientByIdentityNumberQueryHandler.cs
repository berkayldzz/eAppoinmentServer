using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetPatientByIdentityNumber;

internal sealed class GetPatientByIdentityNumberQueryHandler(
    IPatientRepository patientRepository) : IRequestHandler<GetPatientByIdentityNumberQuery, Result<Patient>>
{
    public async Task<Result<Patient>> Handle(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
    {
        Patient? patient =
            await patientRepository
            .GetByExpressionAsync(p => p.IdentityNumber == request.IdentityNumber, cancellationToken);

        return patient;
    }
}

