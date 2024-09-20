using eAppoinmentServer.Domain.Entities;

namespace eAppoinmentServer.Application.Services
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
