using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using eAppoinmentServer.Infrastructure.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppoinmentServer.Infrastructure.Repositories;

internal sealed class AppointmentRepository : Repository<Appointment, ApplicationDbContext>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
