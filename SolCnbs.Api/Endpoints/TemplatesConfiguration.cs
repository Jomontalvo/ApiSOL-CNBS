using System;
using SolCnbs.Data.Repositories;

namespace SolCnbs.Api.Endpoints;

public static class TemplatesConfiguration
{
    public static RouteGroupBuilder MapTemplatesConfiguration(this RouteGroupBuilder builder)
    {
        builder.MapPost("/nombretipotramite", GetProcedureTypeName).WithName("ObtenerNombreTipoTramite");


        //builder.MapGet("/tiposid", GetIdTypeListAsync).WithName("ObtenerTiposId");
        return builder;
    }

    private static async Task<IResult> GetProcedureTypeName(IAuditRegistryRepository repository
    , string token
    , Int64 codigoTramite)
    {
        var result = await repository.GetProcedureTypeAsync(codigoTramite);

        if (!result.IsSuccess)
        {
            return TypedResults.BadRequest(result.Message);
        }

        return TypedResults.Ok(result.Message);
        
    }
}
