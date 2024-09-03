using eAppoinmentServer.Domain.Entities;
using GenericRepository;

namespace eAppoinmentServer.Domain.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
    }
}
