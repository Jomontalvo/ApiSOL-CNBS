using System;

namespace SolCnbs.Common.Models.Dtos;

public class ActionResponse<T> where T : class
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }

}