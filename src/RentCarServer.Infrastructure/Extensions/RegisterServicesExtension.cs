using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarServer.Infrastructure.Context;
using Scrutor;

namespace RentCarServer.Infrastructure.Extensions;

public static class RegisterServicesExtension
{
    public static IServiceCollection AddInfrastructure(
        this ServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefulatConnection")!);
        }); 

        services.Scan(action => action
            .FromAssemblies(typeof(RegisterServicesExtension).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        return services;
    }
}
