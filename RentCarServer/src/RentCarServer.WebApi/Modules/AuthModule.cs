using MediatR;
using RentCarServer.Application.Auth;
using TS.Result;

namespace RentCarServer.WebApi.Modules;

public static class AuthModule
{
    public static void MapAuthEndpoint(this IEndpointRouteBuilder builder)
    {
        var app = builder.MapGroup("/auth");

        app.MapPost("/login",
            async (LoginCommand request, ISender sender, CancellationToken cancellationToken) =>
            {
                var resp = await sender.Send(request);
                return resp.IsSuccessful ? Results.Ok(resp) : Results.BadRequest("User not found!");
            }).Produces<Result<string>>();
    }
}