using SolCnbs.Common.Models.Dtos;
using SolCnbs.Common.Models.Entities;

namespace SolCnbs.Data.Repositories;

public interface IAuditRegistryRepository
{
    Task<ActionResponse<object>> GetTemplateNameAsync(long CodigoTramite);
    Task<ActionResponse<object>> GetProcedureTypeAsync(long CodigoTramite);

    Task<ActionResponse<object>> GetSetRegistryNumberAsync(long CodigoTramite);
    Task<ActionResponse<object>> GetSetResolutionNumberAsync(long CodigoTramite);
}