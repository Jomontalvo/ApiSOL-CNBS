using System;

namespace SolCnbs.Api.Endpoints;

public static class TemplatesConfiguration
{
    public static RouteGroupBuilder MapTemplatesConfiguration(this RouteGroupBuilder builder)
    {
        //builder.MapGet("/tiposid", GetIdTypeListAsync).WithName("ObtenerTiposId");
        return builder;
    }

}
