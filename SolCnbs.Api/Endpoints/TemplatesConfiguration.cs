using SolCnbs.Api.Helpers;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Repositories;

namespace SolCnbs.Api.Endpoints;

public static class TemplatesConfiguration
{
    public static RouteGroupBuilder MapTemplatesConfiguration(this RouteGroupBuilder builder)
    {
        builder.MapGet("/listas/tipostramite", GetProcedureTypeList).WithName("ObtenerTiposTramite");
        builder.MapGet("/listas/moldesdocumentos", GetTemplateList).WithName("ObtenerMoldesDocumentos");
        builder.MapPost("/nombretipotramite", GetProcedureTypeName).WithName("ObtenerNombreTipoTramite");
        builder.MapPost("/nombremolde", GetTemplateDocumentName).WithName("ObtenerNombreMoldeDocumento");
        return builder;
    }


    /// <summary>
    /// Get Procedure Type List
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="campo"></param>
    /// <param name="dependeDe"></param>
    /// <param name="valor"></param>
    /// <returns></returns>
    private static async Task<IResult> GetProcedureTypeList(
            IAuditRegistryRepository repository,
            string? campo,
            string? dependeDe,
            string? valor)
    {
        var procedureTypeListRequest = await repository.GetProcedureTypeListAsync(
            campo, dependeDe, valor);
        return TypedResults.Ok(procedureTypeListRequest.Result);
    }

    /// <summary>
    /// Get Template List by Procedure Type
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="campo"></param>
    /// <param name="dependeDe"></param>
    /// <param name="valor"></param>
    /// <returns></returns>
    private static async Task<IResult> GetTemplateList(
            IAuditRegistryRepository repository,
            string? campo,
            string? dependeDe,
            string? valor)
    {
        var templateListRequest = await repository.GetTemplateListAsync(
            campo,
            dependeDe,
            valor!.GetIntBeforeDash().ToString());
        return TypedResults.Ok(templateListRequest.Result);
    }

    /// <summary>
    /// Get Procedure Type Name
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="datosTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetProcedureTypeName(
        IAuditRegistryRepository repository,
        SolCallParameters datosTramite)
    {
        if (datosTramite is null)
            return TypedResults.BadRequest("Error: Debe especificar los parámteros de llamada.");

        var result = await repository.GetProcedureTypeAsync(datosTramite.ProcedureCode);
        return TypedResults.Ok(await result.MapToSolResponse());
    }

    /// <summary>
    /// Get Documento Template Name
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="datosTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetTemplateDocumentName(
    IAuditRegistryRepository repository,
    SolCallParameters datosTramite)
    {
        if (datosTramite is null)
            return TypedResults.BadRequest("Error: Debe especificar los parámetros de llamada.");

        var result = await repository.GetTemplateNameAsync(datosTramite.ProcedureCode);
        return TypedResults.Ok(await result.MapToSolResponse());
    }
}
