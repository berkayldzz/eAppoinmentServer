using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId;

// Doktorun randevularını al
internal sealed class GetAllAppointmentsByDoctorIdHandler(IAppointmentRepository appointmentRepository) : IRequestHandler<GetAllAppointmentsByDoctorIdQuery, Result<List<GetAllAppointmentsByDoctorIdResponse>>>
{
    public async Task<Result<List<GetAllAppointmentsByDoctorIdResponse>>> Handle(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
    {
        List<Appointment> appoinments = await appointmentRepository.Where(p => p.DoctorId == request.DoctorId).Include(p=>p.Patient).ToListAsync(cancellationToken);

        // Appointment listemi aldıktan sonra oluşturduğum responsa çevirmem lazım.

        List<GetAllAppointmentsByDoctorIdResponse> response =
            appoinments.Select(s => new GetAllAppointmentsByDoctorIdResponse(
                s.Id,
                s.StartDate,
                s.EndDate,
                s.Patient!.FullName,
                s.Patient)).ToList();

        return response;
    }
}
