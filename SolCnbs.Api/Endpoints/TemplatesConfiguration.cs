using Microsoft.AspNetCore.Mvc;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Repositories;
using System;

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
