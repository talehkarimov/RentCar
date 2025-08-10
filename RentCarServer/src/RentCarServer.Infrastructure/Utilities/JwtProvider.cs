using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RentCarServer.Application.Services;
using RentCarServer.Domain.Users;
using RentCarServer.Infrastructure.Constants;
using RentCarServer.Infrastructure.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentCarServer.Infrastructure.Utilities;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtClaimTypes.FullName, user.FullName.Value),
            new Claim(JwtClaimTypes.Email, user.Email.Value)

        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        var securityToken = new JwtSecurityToken
            (
                issuer: options.Value.Issuer,
                audience: options.Value.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(1)
            );

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(securityToken);
        return token;
    }
}
