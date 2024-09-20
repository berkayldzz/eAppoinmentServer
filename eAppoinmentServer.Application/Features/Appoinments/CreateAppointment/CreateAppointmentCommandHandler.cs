using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.CreateAppointment;


internal sealed class CreateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork,
    IPatientRepository patientRepository) : IRequestHandler<CreateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        // Hasta kayıtlı değilse onu kaydediyoruz.ID si yoksa.
        Patient patient = new();

        if (request.PatientId is null)
        {
            patient = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdentityNumber = request.IdentityNumber,
                City = request.City,
                Town = request.Town,
                FullAddress = request.FullAddress
            };

            await patientRepository.AddAsync(patient, cancellationToken);
        }

        Appointment appointment = new()
        {
            DoctorId = request.DoctorId,
            PatientId = request.PatientId ?? patient.Id,
            StartDate = Convert.ToDateTime(request.StartDate),
            EndDate = Convert.ToDateTime(request.EndDate),
            IsCompleted = false
        };

        await appointmentRepository.AddAsync(appointment, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Appointment create is successful";
    }

}
