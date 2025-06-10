using SolCnbs.Common.Models.Dtos;

namespace SolCnbs.Data.Repositories;

public interface IAuditRegistryRepository
{
    Task<ActionResponse<object>> GetTemplateNameAsync(long codigoTramite);

    Task<ActionResponse<object>> GetProcedureTypeAsync(long codigoTramite);

}
