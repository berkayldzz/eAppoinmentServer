using AutoMapper;
using eAppoinmentServer.Application.Features.Doctors.CreateDoctor;
using eAppoinmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppoinmentServer.Application.Features.Patients.CreatePatient;
using eAppoinmentServer.Application.Features.Patients.UpdatePatient;
using eAppoinmentServer.Application.Features.Users.CreateUser;
using eAppoinmentServer.Application.Features.Users.UpdateUser;
using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppoinmentServer.Application.Mapping
{
    public sealed class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
            {
                options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
            });
            CreateMap<UpdateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
            {
                options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
            });
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<UpdatePatientCommand, Patient>();

            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();
           
        }

    }
}
