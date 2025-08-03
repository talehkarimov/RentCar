﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace RentCarServer.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableQuery]
public class oDataController : ControllerBase
{
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new ();
        builder.EnableLowerCamelCase();
        return builder.GetEdmModel();
    }
}
