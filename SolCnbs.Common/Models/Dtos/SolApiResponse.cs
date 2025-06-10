using System.Text.Json.Serialization;

namespace SolCnbs.Common.Models.Dtos;

public class SolApiResponse
{
    [JsonPropertyName("resultado")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("mensaje")]
    public string? Message { get; set; }

}
