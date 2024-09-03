using eAppoinmentServer.Domain.Entities;

namespace eAppoinmentServer.Application.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}
