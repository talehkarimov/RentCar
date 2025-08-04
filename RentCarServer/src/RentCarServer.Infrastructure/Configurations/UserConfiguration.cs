﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarServer.Domain.Users;

namespace RentCarServer.Infrastructure.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.FirstName);
        builder.OwnsOne(x => x.LastName);
        builder.OwnsOne(x => x.FullName);
        builder.OwnsOne(x => x.Email);
        builder.OwnsOne(x => x.UserName);
        builder.OwnsOne(x => x.Password);
    }
}
