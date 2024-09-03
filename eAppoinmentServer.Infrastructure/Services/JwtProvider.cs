using eAppoinmentServer.Application.Services;
using eAppoinmentServer.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAppoinmentServer.Infrastructure.Services;

internal sealed class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        //Claim, kullanıcıya ilişkin belirli bir özelliği veya bilgiyi temsil eden bir anahtar-değer çiftidir. Örneğin, kullanıcı kimliği, kullanıcı adı, e-posta adresi gibi bilgiler birer Claim olarak taşınabilir.

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim("UserName", user.UserName ?? string.Empty),

        };

        DateTime expires = DateTime.Now.AddDays(1);

        SymmetricSecurityKey securityKey =
            new(Encoding.UTF8.GetBytes(string.Join("-", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())));


        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: "Berkay Yıldız",
            audience: "eAppointment",
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;

    }
}
