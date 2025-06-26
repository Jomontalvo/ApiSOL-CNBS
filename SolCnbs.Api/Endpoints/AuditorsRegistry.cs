using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Repositories;

namespace SolCnbs.Api.Endpoints;

public static class AuditorsRegistry
{
    public static RouteGroupBuilder MapAuditorsRegistry(this RouteGroupBuilder builder)
    {
        builder.MapPost("/numero", GetRegistryNumber).WithName("ObtenerNumeroRegistro");
        builder.MapPost("/numeroresolucion", GetResolutionNumber).WithName("ObtenerNumeroResolucion");
        builder.MapPost("/numeroresolucionactualizacion", GetResolutionNumber).WithName("ObtenerNumeroResolucionActualizacion");
        builder.MapPost("/numeroresolucionreclasificacion", GetResolutionNumber).WithName("ObtenerNumeroResolucionReclasificacion");
        return builder;
    }


    /// <summary>
    /// Get Registry Number
    /// </summary>
    /// <param name="datosTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetRegistryNumber(
         IAuditRegistryRepository repository,
    SolCallParameters datosTramite)
    {
        if (datosTramite is null)
            return TypedResults.BadRequest("Error: Debe especificar los parámetros de llamada.");

        var result = await repository.GetSetRegistryNumberAsync(datosTramite.ProcedureCode);
        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Get Resolution Number(Register)
    /// </summary>
    /// <param name="datosTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetResolutionNumber(
         IAuditRegistryRepository repository,
    SolCallParameters datosTramite)
    {
        if (datosTramite is null)
            return TypedResults.BadRequest("Error: Debe especificar los parámetros de llamada.");

        var result = await repository.GetSetResolutionNumberAsync(datosTramite.ProcedureCode);
        return TypedResults.Ok(result);
    }

}
