using Microsoft.AspNetCore.Identity;

namespace eAppoinmentServer.Domain.Entities
{
    // User ile Role ilişkilendirecek classımız
    public sealed class AppUserRole : IdentityUserRole<Guid>
    {
        // IdentityUserRole de RoleId ve UserId tanımlanmış durumda
    }
}
