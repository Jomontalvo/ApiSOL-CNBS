using Microsoft.EntityFrameworkCore;
using SolCnbs.Common;
using SolCnbs.Common.Models.Dtos;
using SolCnbs.Common.Models.Entities;
using SolCnbs.Data.Context;

namespace SolCnbs.Data.Repositories;

public class AuditRegisterRepositories(SolDbContext Context) : IAuditRegisterRepositories
{
    


    public async Task<ActionResponse<object>> GetProcedureTypeAsync(Int64 CodigoTramite)
    {
        try
        {
            var TemplateOption = await Context.TemplateOption.FirstOrDefaultAsync(x => x.CodigoRegistro == CodigoTramite);

            if (TemplateOption is null)
                return new ActionResponse<object>() { IsSuccess = false, Message = "TemplateOption is Null" };

            var CodProcedureType = TemplateOption?.CodigoTipoTramite;
            var ProcedureType = await Context.ProcedureType.FirstOrDefaultAsync(x => x.CodigoTipoTramite == CodigoTramite);

            TemplateOption.NombreMolde = ProcedureType!.Nombre;
            await Context.SaveChangesAsync();

            return new ActionResponse<object>() { IsSuccess = true, Message = "Success!!!" };
        }
        catch (Exception ex)
        {
            return new ActionResponse<object>() { IsSuccess = false, Message = ex.FullMessage() };
        }
       
    }

    public Task<ActionResponse<object>> GetTemplateNameAsync(Int64 CodigoTramite)
    {
        throw new NotImplementedException();
    }
}
