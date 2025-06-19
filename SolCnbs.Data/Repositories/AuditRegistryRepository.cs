using Microsoft.EntityFrameworkCore;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Context;

namespace SolCnbs.Data.Repositories;

public class AuditRegistryRepository(SolDbContext context) : IAuditRegistryRepository
{

    /// <summary>
    /// Get procedure type list
    /// </summary>
    /// <param name="campo"></param>
    /// <param name="dependeDe"></param>
    /// <param name="valor"></param>
    /// <returns></returns>
    public async Task<ActionResponse<IEnumerable<string>>> GetProcedureTypeListAsync(
        string? campo, string? dependeDe, string? valor)
    {
        try
        {
            var requestList = await context.ProcedureTypes
                .AsNoTracking()
                .Select(x => string.Concat(x.CodigoTipoTramite, " - ", x.Nombre))
                .ToListAsync();
            return new ActionResponse<IEnumerable<string>>
            {
                IsSuccess = true,
                Result = requestList
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<string>>
            {
                IsSuccess = false,
                Message = ex.Message,
                Result = []
            };
        }
    }

    /// <summary>
    /// Get Template List by Procedure Type
    /// </summary>
    /// <param name="campo"></param>
    /// <param name="dependeDe"></param>
    /// <param name="valor"></param>
    /// <returns></returns>
    public async Task<ActionResponse<IEnumerable<ItemListResponse>>> GetTemplateListAsync(
        string? campo, string? dependeDe, string? valor)
    {
        try
        {
            var resultList = await (
                from tt in context.ProcedureTypes.AsNoTracking()
                join mdt in context.Templates.AsNoTracking()
                    on tt.CodigoTipoTramite equals mdt.CodigoTipoTramite
                where tt.CodigoTipoTramite == Convert.ToInt32(valor)
                select new ItemListResponse
                {
                    Parent = tt.CodigoTipoTramite + " - " + tt.Nombre,
                    Value = mdt.CodigoMoldeDocumento + " - " + mdt.NombreMolde
                }).ToListAsync();

            return new ActionResponse<IEnumerable<ItemListResponse>>
            {
                IsSuccess = true,
                Result = resultList
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<ItemListResponse>>
            {
                IsSuccess = false,
                Message = ex.Message,
                Result = []
            };

        }
    }

    /// <summary>
    /// Get procedure type name
    /// </summary>
    /// <param name="codigoTramite"></param>
    /// <returns></returns>
    public async Task<ActionResponse<object>> GetProcedureTypeAsync(long codigoTramite)
    {
        try
        {
            var templateResult = await context.TemplateOptions.FindAsync(codigoTramite);

            if (templateResult is null)
            {
                return new ActionResponse<object>
                {
                    IsSuccess = false,
                    Message = $"Error: El registro con código [{codigoTramite}] no existe."
                };
            }
            var codigoTipoTramite = templateResult.CodigoTipoTramite;

            var procTypeResult = await context.ProcedureTypes
                .AsNoTracking().SingleOrDefaultAsync(x => x.CodigoTipoTramite == codigoTipoTramite);

            if (procTypeResult is null)
                return new ActionResponse<object>
                {
                    IsSuccess = false,
                    Message = $"Error: El tipo de trámite buscado [{codigoTipoTramite}] no existe."
                };

            var procedureTypeName = procTypeResult.Nombre;
            templateResult.NombreTramite = procedureTypeName;

            await context.SaveChangesAsync();

            return new ActionResponse<object>
            {
                IsSuccess = true,
                Message = "Datos del tipo de trámite actualizados exitosamente."
            };

        }
        catch (Exception ex)
        {
            return new ActionResponse<object>
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    /// <summary>
    /// Get document template name
    /// </summary>
    /// <param name="codigoTramite"></param>
    /// <returns></returns>
    public async Task<ActionResponse<object>> GetTemplateNameAsync(long codigoTramite)
    {
        try
        {
            var templateResult = await context.TemplateOptions.FindAsync(codigoTramite);

            if (templateResult is null)
            {
                return new ActionResponse<object>
                {
                    IsSuccess = false,
                    Message = $"Error: El registro con código [{codigoTramite}] no existe."
                };
            }
            var documentTemplateId = Convert.ToInt32(templateResult.CodigoMolde);

            var docResult = await context.Templates.AsNoTracking()
                .SingleOrDefaultAsync(x => x.CodigoMoldeDocumento == documentTemplateId);

            if (docResult is null)
                return new ActionResponse<object>
                {
                    IsSuccess = false,
                    Message = $"Error: El código de molde de documento anexo [{documentTemplateId}] no existe."
                };

            var templateName = docResult!.NombreMolde;
            templateResult.NombreMolde = templateName;

            await context.SaveChangesAsync();

            return new ActionResponse<object>
            {
                IsSuccess = true,
                Message = "Datos del molde de documento anexo actualizados."
            };

        }
        catch (Exception ex)
        {
            return new ActionResponse<object>
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }

    }
}

