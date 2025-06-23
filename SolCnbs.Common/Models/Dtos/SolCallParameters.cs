using System.Text.Json.Serialization;

namespace SolCnbs.Common.Models.Dtos;

public class SolCallParameters
{

    [JsonPropertyName("token")]
    public string Token { get; set; } = default!;

    [JsonPropertyName("codigoTramite")]
    public long ProcedureCode { get; set; }

}

public class SolCompletionCallParameters : SolCallParameters
{
    [JsonPropertyName("aprobado")]
    public bool Approved { get; set; }

    [JsonPropertyName("aprobacionParcial")]
    public bool PartialApproved { get; set; }
}