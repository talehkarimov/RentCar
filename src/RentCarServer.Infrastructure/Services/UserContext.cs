using Microsoft.AspNetCore.Http;
using RentCarServer.Application.Services;
using System.Security.Claims;

namespace RentCarServer.Infrastructure.Services;

internal sealed class UserContext(
        HttpContextAccessor httpContextAccessor
    ) : IUserContext
{
    public Guid GetUserId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext.User.Claims;
        string? userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) throw new ArgumentException("User not found!");

        try
        {
            Guid id = Guid.Parse(userId);
            return id;
        }
        catch (Exception)
        {
            throw new ArgumentException("Wrong guid format!");
        }
    }
}
