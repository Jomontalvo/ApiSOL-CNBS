using SolCnbs.Data.Repositories;

namespace SolCnbs.Api.Endpoints;

public static class TemplatesConfiguration
{
    public static RouteGroupBuilder MapTemplatesConfiguration(this RouteGroupBuilder builder)
    {
        builder.MapPost("/nombretipotramite", GetProcedureTypeName).WithName("ObtenerNombreTipoTramite");
        builder.MapPost("/nombremolde", GetTemplateDocumentName).WithName("ObtenerNombreMoldeDocumento");
        return builder;
    }

    /// <summary>
    /// Get Procedure Type Name
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="token"></param>
    /// <param name="codigoTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetProcedureTypeName(
        IAuditRegistryRepository repository,
        string? token,
        long codigoTramite)
    {
        if (codigoTramite == 0)
            return TypedResults.BadRequest("Error: Debe especificar el tipo de trámite.");

        var result = await repository.GetProcedureTypeAsync(codigoTramite);
        if (!result.IsSuccess)
            return TypedResults.BadRequest(result.Message);

        return TypedResults.Ok(result.Message);
    }

    /// <summary>
    /// Get Documento Template Name
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="token"></param>
    /// <param name="codigoTramite"></param>
    /// <returns></returns>
    private static async Task<IResult> GetTemplateDocumentName(
    IAuditRegistryRepository repository,
    string? token,
    long codigoTramite)
    {
        if (codigoTramite == 0)
            return TypedResults.BadRequest("Error: Debe especificar el tipo de molde de decumento anexo.");

        var result = await repository.GetTemplateNameAsync(codigoTramite);
        if (!result.IsSuccess)
            return TypedResults.BadRequest(result.Message);

        return TypedResults.Ok(result.Message);
    }
}
