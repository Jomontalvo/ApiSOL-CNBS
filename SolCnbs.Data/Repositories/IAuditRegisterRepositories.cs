using SolCnbs.Common.Models.Dtos;
using SolCnbs.Common.Models.Entities;

namespace SolCnbs.Data.Repositories;

public interface IAuditRegisterRepositories
{
    Task<ActionResponse<object>> GetTemplateNameAsync(Int64 CodigoTramite);
    Task<ActionResponse<object>> GetProcedureTypeAsync(Int64 CodigoTramite);
}