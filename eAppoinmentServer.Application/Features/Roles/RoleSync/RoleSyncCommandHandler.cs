using eAppoinmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppoinmentServer.Application.Features.Roles.RoleSync;

// Role ile ilgili işlemleri RoleManager sayesinde yapabiliyoruz.
internal sealed class RoleSyncCommandHandler(RoleManager<AppRole> roleManager) : IRequestHandler<RoleSyncCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        // db de bulunan tüm rolleri alıyorum.
        List<AppRole> currentRole = await roleManager.Roles.ToListAsync(cancellationToken);

        // kendim oluşturduğum rolleri alıyorum.

        List<AppRole> staticRole= Constants.GetRoles();

        foreach (var role in currentRole)
        {
            // dbdeki role benim statik olarak oluşturduğum rollerin içinde yoksa bu rolü sil.
            if(!staticRole.Any(p=>p.Name== role.Name))
            {
                await roleManager.DeleteAsync(role);
            }
        }
        // dbdeki rolde benim statik olarak oluşturduğum rol yoksa bunu ekle. 
        foreach (var role in staticRole)
        {
            if (!currentRole.Any(p => p.Name == role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }

        return "Sync is successful";
    }
}
