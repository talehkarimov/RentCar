﻿using RentCarServer.Domain.Abstractions;
using RentCarServer.Domain.Users.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace RentCarServer.Domain.Users;

public sealed class User : Entity
{
    private User() { }

    public User(
        FirstName firstName, 
        LastName lastName, 
        Email email, 
        Username userName,
        Password password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        FullName = new(FirstName.Value + " " + LastName.Value + " (" + Email.Value + ")");
        UserName = userName;
        Password = password;
    }

    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public FullName FullName { get; private set; } = default!;
    public Username UserName { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    public bool VerifyPasswordHash(string password)
    {
        using var hmac = new HMACSHA512(Password.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(Password.PasswordHash);
    }
}