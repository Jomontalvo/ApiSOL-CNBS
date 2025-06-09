using System;
using Microsoft.EntityFrameworkCore;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Context;

namespace SolCnbs.Data.Repositories;

public class AuditRegistryRepository(SolDbContext context) : IAuditRegistryRepository
{
    public async Task<ActionResponse<object>> GetProcedureTypeAsync(long codigoTramite)
    {
        var templateResult = await context.TemplateOptions.FirstOrDefaultAsync(x => x.CodigoRegistro == codigoTramite);

        if (templateResult is null)
        {
            return new ActionResponse<object> { IsSuccess = false, Message = "Debe especificar el tipo de trámite" };
        }
        var codigoTipoTramite = templateResult.CodigoTipoTramite;

        var procTypeResult = await context.ProcedureTypes.FirstOrDefaultAsync(x => x.CodigoTipoTramite == codigoTipoTramite);

        var procedureTypeName = procTypeResult!.Nombre;

        templateResult.NombreMolde = procedureTypeName;

        await context.SaveChangesAsync();

        return new ActionResponse<object> { IsSuccess = true, Message = "Tipo de procedimiento encontrado" };

    }

    public Task<ActionResponse<object>> GetTemplateNameAsync(long codigoTramite)
    {
        
        //var codigoMolde = templateResult.CodigoMolde;
        throw new NotImplementedException();
    }
}

