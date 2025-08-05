using GenericRepository;
using RentCarServer.Domain.Users;
using RentCarServer.Domain.Users.ValueObjects;

namespace RentCarServer.WebApi.Extensions;

public static class ExtensionMethods
{
    public static async Task CreateFirstUserAsync(this WebApplication webApplication)
    {
        using var scoped = webApplication.Services.CreateScope();
        var userRepository = scoped.ServiceProvider.GetRequiredService<IUserRepository>();
        var unitOfWork = scoped.ServiceProvider.GetRequiredService<IUnitOfWork>();

        if(!await userRepository.AnyAsync(u => u.UserName.Value == "admin"))
        {
            FirstName firstName = new("Taleh");
            LastName lastName = new("Karimov");
            Email email = new("talehwork@gmail.com");
            Username username = new("admin");
            Password password = new("1");

            var user = new User(firstName, lastName, email, username, password);
            
            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
