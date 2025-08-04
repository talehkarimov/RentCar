﻿using System.Security.Cryptography;
using System.Text;

namespace RentCarServer.Domain.Users.ValueObjects;

public sealed record Password
{
    private Password() { }

    public Password(string password)
    {
        CreatePasswordHash(password);
    }
    public byte[] PasswordHash { get; private set; } = default!;
    public byte[] PasswordSalt { get; private set; } = default!;

    private void CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        PasswordSalt = hmac.Key;
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}