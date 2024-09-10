using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using eAppoinmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppoinmentServer.Infrastructure.Repositories;


internal sealed class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }
}
