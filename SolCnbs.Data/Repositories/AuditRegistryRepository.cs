using SolCnbs.Common.Models.Dtos;
using SolCnbs.Data.Context;

namespace SolCnbs.Data.Repositories;

public class AuditRegistryRepository(SolDbContext context) : IAuditRegistryRepository
{
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
                    Message = "Error: El código de trámite ingresado no existe."
                };
            }
            var codigoTipoTramite = templateResult.CodigoTipoTramite;

            var procTypeResult = await context.ProcedureTypes.FindAsync(codigoTipoTramite);
            var procedureTypeName = procTypeResult!.Nombre;
            templateResult.NombreTramite = procedureTypeName;

            await context.SaveChangesAsync();

            return new ActionResponse<object>
            {
                IsSuccess = true,
                Message = "Datos actualizados exitosamente (tipo de trámite encontrado)."
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
                    Message = "Error: El código de molde de documento anexo ingresado no existe."
                };
            }
            var documentTemplateId = Convert.ToInt32(templateResult.CodigoMolde);

            var docResult = await context.Templates.FindAsync(documentTemplateId);
            var templateName = docResult!.NombreMolde;
            templateResult.NombreMolde = templateName;

            await context.SaveChangesAsync();

            return new ActionResponse<object>
            {
                IsSuccess = true,
                Message = "Datos actualizados (tipo de molde de documento anexo encontrado)."
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

