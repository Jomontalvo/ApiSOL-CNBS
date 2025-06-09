using System;
using SolCnbs.Common.Models.Dtos;

namespace SolCnbs.Data.Repositories;

public interface IAuditRegistryRepository
{
    Task<ActionResponse<object>> GetTemplateNameAsync(Int64 codigoTramite);

    Task<ActionResponse<object>> GetProcedureTypeAsync(Int64 codigoTramite);

}
