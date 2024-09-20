using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId;


// Doctorun randevularını getirme 
public sealed record GetAllAppointmentsByDoctorIdQuery(Guid DoctorId) :IRequest<Result<List<GetAllAppointmentsByDoctorIdResponse>>>;
