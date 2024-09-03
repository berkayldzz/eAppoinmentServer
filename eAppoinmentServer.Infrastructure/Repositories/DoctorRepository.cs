using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using eAppoinmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppoinmentServer.Infrastructure.Repositories;

internal sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
