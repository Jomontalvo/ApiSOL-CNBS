using Microsoft.AspNetCore.Mvc;
using SolCnbs.Data.Repositories;
using System;

namespace SolCnbs.Api.Endpoints;

public static class TemplatesConfiguration
{
    public static RouteGroupBuilder MapTemplatesConfiguration(this RouteGroupBuilder builder)
    {
        //builder.MapGet("/tiposid", GetIdTypeListAsync).WithName("ObtenerTiposId");
        builder.MapPost("/nombretipotramite", ProcedureTypeName).WithName("ObtenerNombreTipoTramite");
        return builder;
    }

    private static async Task<IResult> ProcedureTypeName([FromServices] IAuditRegisterRepositories AuditRegisterRepositories, [FromQuery] Int64 codigoTramite, [FromQuery] string token)
    {
        var result = await AuditRegisterRepositories.GetProcedureTypeAsync(codigoTramite);

        if(!result.IsSuccess) 
            return TypedResults.BadRequest(result.Message);

        return TypedResults.Ok(result.Message);
    }
}
