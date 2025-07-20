﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarServer.Domain.Abstractions;

namespace RentCarServer.Infrastructure.Converters;

internal sealed class IdentityIdValueConverter : ValueConverter<IdentityId, Guid>
{
    public IdentityIdValueConverter() : base(m => m.Value, m => new IdentityId(m))
    {
    }
}
