using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Repositories;
using eAppoinmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppoinmentServer.Infrastructure.Repositories
{
    internal sealed class UserRoleRepository : Repository<AppUserRole, ApplicationDbContext>,IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
