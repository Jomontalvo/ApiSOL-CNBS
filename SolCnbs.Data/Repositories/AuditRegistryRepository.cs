using Microsoft.EntityFrameworkCore;
using SolCnbs.Common;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Common.Models.Entities;
using SolCnbs.Data.Context;

namespace SolCnbs.Data.Repositories;

public class AuditRegistryRepository(SolDbContext Context, CodesDbContext CodesContext) : IAuditRegistryRepository
{    
    public async Task<ActionResponse<object>> GetProcedureTypeAsync(long codigoTramite)
    {
        try
        {
            var templateResult = await Context.TemplateOptions.FindAsync(codigoTramite);

            if (templateResult is null)
                return new ActionResponse<object>(false, $"Error: El registro con código [{codigoTramite}] no existe.");

            var codigoTipoTramite = templateResult.CodigoTipoTramite;
            var procTypeResult = await Context.ProcedureTypes
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(x => x.CodigoTipoTramite == codigoTramite);

            if (procTypeResult is null)
                return new ActionResponse<object>(false, $"Error: El tipo de trámite buscado [{codigoTipoTramite}] no existe.");

            templateResult.NombreMolde = procTypeResult!.Nombre;
            await Context.SaveChangesAsync();

            return new ActionResponse<object>(true, "Datos del tipo de trámite actualizados exitosamente.");
        }
        catch (Exception ex)
        {
            return new ActionResponse<object>(false, ex.FullMessage());
        }
       
    }

    public async  Task<ActionResponse<object>> GetTemplateNameAsync(long codigoTramite)
    {
        try
        {
            var templateResult = await Context.TemplateOptions.FindAsync(codigoTramite);

            if (templateResult is null)
                return new ActionResponse<object>(false, $"Error: El registro con código [{codigoTramite}] no existe.");

            var documentTemplateId = Convert.ToInt32(templateResult.CodigoMolde);

            var docResult = await Context.Templates
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(x => x.CodigoMoldeDocumento == documentTemplateId);

            if (docResult is null)
                return new ActionResponse<object>(false, $"Error: El código de molde de documento anexo [{documentTemplateId}] no existe.");
          
            templateResult.NombreMolde = docResult!.NombreMolde;
            await Context.SaveChangesAsync();

            return new ActionResponse<object>(true, "Datos del molde de documento anexo actualizados.");

        }
        catch (Exception ex)
        {
            return new ActionResponse<object>(false, ex.FullMessage());
        }
    }

    public async Task<ActionResponse<object>> GetSetRegistryNumberAsync(long codigoTramite)
    {
        try
        {
            var Procedure = await Context.Procedures.FindAsync(codigoTramite);

            if (Procedure is null)
                return new ActionResponse<object>(false, $"Error: El registro con código [{codigoTramite}] no existe.");

            //RAERP-RE-1-2025


            var Number = CodesContext.Database.SqlQueryRaw<string>("EXEC [dbo].[GetNumero] @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
                                           "RAE",
                                           "RP",
                                           "RE",
                                           DateTime.Now.Year.ToString(),
                                           "RAE",
                                           "SOL API",
                                           "00",
                                           "REG",
                                           "SOL").AsEnumerable().FirstOrDefault();

            Procedure.CodigoCodificador = Number;
            await Context.SaveChangesAsync();

            return new ActionResponse<object>(true, "Código Codificador ha sido actualizado.");

        }
        catch (Exception ex)
        {
            return new ActionResponse<object>(false, ex.FullMessage());
        }
    }

    public async Task<ActionResponse<object>> GetSetResolutionNumberAsync(long codigoTramite)
    {
        try
        {
            var TipoTramite = Context.Database.SqlQueryRaw<int?>("SELECT codigo_tipo_tramite FROM tramite WHERE codigo_tramite = @p0", codigoTramite).ToList().FirstOrDefault();

            if (!TipoTramite.HasValue && TipoTramite!.Value > 0)
                return new ActionResponse<object>(false, $"Error: El registro con código [{codigoTramite}] no existe.");

            var Tipo = TipoTramite.Value switch { 
                1 => "RE", 
                2 => "RD", 
                4 => "RB" };

            var Number = CodesContext.Database.SqlQueryRaw<string>("EXEC [dbo].[GetNumeroResolucion] @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
                                           "GPU",
                                           Tipo,
                                           "RA",
                                           DateTime.Now.ToString("dd-MM-yyyy"),
                                           "RAE",
                                           "SOL API",
                                           "00",
                                           "REG",
                                           "SOL").AsEnumerable().FirstOrDefault();
            
            var r = await Context.Database.ExecuteSqlRawAsync($"UPDATE datos_adicionales_{TipoTramite.Value} SET codigo_documento = @p0 WHERE codigo_tramite = @p1", Number!, codigoTramite);

            return new ActionResponse<object>(true, "Número de Resolución ha sido actualizado.");

        }
        catch (Exception ex)
        {
            return new ActionResponse<object>(false, ex.FullMessage());
        }
    }
}
