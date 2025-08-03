using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentCarServer.Application.Behaviours;

namespace RentCarServer.Application.Extensions;

public static class RegisterServicesExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cnf =>
        {
            cnf.RegisterServicesFromAssembly(typeof(RegisterServicesExtension).Assembly);
            cnf.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(typeof(RegisterServicesExtension).Assembly);

        return services;
    }
}
