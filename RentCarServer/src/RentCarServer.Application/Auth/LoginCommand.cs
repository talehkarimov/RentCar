using FluentValidation;
using MediatR;
using RentCarServer.Application.Services;
using RentCarServer.Domain.Users;
using TS.Result;

namespace RentCarServer.Application.Auth;

public sealed record LoginCommand(
        string UserNameOrEmail,
        string Password) : IRequest<Result<string>>;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.UserNameOrEmail).NotEmpty().WithMessage("Username or email can not be empty!");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Password can not be empty!");
    }
}

public sealed class LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .FirstOrDefaultAsync(u => u.UserName.Value == request.UserNameOrEmail
                || u.Email.Value == request.UserNameOrEmail, cancellationToken);
        if (user == null) return Result<string>.Failure("User info or password is not correct");

        bool checkPassword = user.VerifyPasswordHash(request.Password);
        if(!checkPassword) return Result<string>.Failure("User info or password is not correct");

        var token = jwtProvider.CreateToken(user);
        return token;
    }
}