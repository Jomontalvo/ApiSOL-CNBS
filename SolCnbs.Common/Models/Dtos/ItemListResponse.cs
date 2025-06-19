using System;
using System.Text.Json.Serialization;

namespace SolCnbs.Common.Models.Dtos;

public class ItemListResponse
{
    [JsonPropertyName("grupo")]
    public string Parent { get; set; } = default!;

    [JsonPropertyName("valor")]
    public string Value { get; set; } = default!;

}
