using Microsoft.AspNetCore.Identity;

namespace eAppoinmentServer.Domain.Entities
{
    // sealed: Bu classın başka bir clasa inherit olamasını engeller
    public sealed class AppUser:IdentityUser<Guid>
    {
        // ekstra yer almasını istediğim bilgiler
        public string FirstName { get; set; } =string .Empty;
        public string LastName { get; set; } =string .Empty;

        // Dışarıda kullanabileceğimiz database de geçmeyen bir property
        // Firstname ve lastname db ye kaydolucak. appuser içindeki fullnamei çağırdığımda bu property birleştirme işlemi yapacak
        public string FullName =>string.Join (" ", FirstName,LastName);
    }
}
