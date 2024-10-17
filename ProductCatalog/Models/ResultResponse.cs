using System.Diagnostics.CodeAnalysis;

namespace ProductCatalog.Models;

public class ResultResponse<T> where T : class
{

    [MemberNotNullWhen(true, nameof(Result))]
    public bool Succeeded { get; init; }
    public string? Message { get; init; }
    public T? Result { get; init; }

    public ResultResponse(bool succeeded, string? message = null, T? result = default)
    {
        Succeeded = succeeded;
        Message = message;
        Result = result;
    }

    public static ResultResponse<T> Ok(T value)
    {
        return new ResultResponse<T>(succeeded: true, message: null, value);
    }
    public static ResultResponse<T> Error(string message)
    {
        return new ResultResponse<T>(succeeded: false, message);
    }
    
}