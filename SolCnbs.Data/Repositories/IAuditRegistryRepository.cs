using SolCnbs.Common.Models.Dtos;

namespace SolCnbs.Data.Repositories;

public interface IAuditRegistryRepository
{
    Task<ActionResponse<object>> GetTemplateNameAsync(long codigoTramite);

    Task<ActionResponse<object>> GetProcedureTypeAsync(long codigoTramite);

    Task<ActionResponse<IEnumerable<string>>> GetProcedureTypeListAsync(string? campo, string? dependeDe, string? valor);

    Task<ActionResponse<IEnumerable<ItemListResponse>>> GetTemplateListAsync(string? campo, string? dependeDe, string? valor);

}
