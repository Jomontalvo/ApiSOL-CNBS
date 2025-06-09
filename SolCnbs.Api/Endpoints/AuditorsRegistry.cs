using System;

namespace SolCnbs.Api.Endpoints;

public static class AuditorsRegistry
{
    public static RouteGroupBuilder MapAuditorsRegistry(this RouteGroupBuilder builder)
    {
        //builder.MapGet("/tiposid", GetIdTypeListAsync).WithName("ObtenerTiposId");
        return builder;
    }

}
