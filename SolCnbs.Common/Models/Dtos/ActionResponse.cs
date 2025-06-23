using System;

namespace SolCnbs.Common.Models.Dtos;

public class ActionResponse<T> where T : class
{

    public ActionResponse()
    {
        
    }

    public ActionResponse(bool IsSuccess, string Message)
    {
        this.IsSuccess = IsSuccess;
        this.Message = Message;
    }

    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }

    /// <summary>
    /// Mapping ActionResult to Sal API result
    /// </summary>
    /// <returns></returns>
    public async Task<SolApiResponse> MapToSolResponse()
    {

        return await Task.FromResult(new SolApiResponse
        {
            IsSuccess = IsSuccess,
            Message = Message
        });
    }
}