using AutoMapper;
using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Doctors.CreateDoctor;

internal sealed class CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork,IMapper mapper) : 
IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        //Doctor doctor = new()
        //{
        //    FirstName = request.FirstName,
        //    LastName = request.LastName,
        //    Department = DepartmentEnum.FromValue(request.Department),
        //};

        // Yukarıdaki kodu automapper kütüphanesi ile daha kısa hale getirdik.

        Doctor doctor = mapper.Map<Doctor>(request);

        await doctorRepository.AddAsync(doctor,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doctor create is successful";
    }
}
