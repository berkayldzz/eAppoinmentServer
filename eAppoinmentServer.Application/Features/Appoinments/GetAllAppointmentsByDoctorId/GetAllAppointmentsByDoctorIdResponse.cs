using eAppoinmentServer.Domain.Entities;

namespace eAppoinmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId;

// Buraya geri döncüreceğim değer doktor listesi veya appoinment listesi olamaz. Çünkü başlangıç tarihi , title gibi alanların olması lazım.Kurduğumuz yapıda onları kullanıcıya gösteriyoruz.

public sealed record GetAllAppointmentsByDoctorIdResponse(Guid Id,DateTime StartDate,DateTime EndDate,string Title,Patient Patient);
