using System.Net;

namespace MinimalApiRealState.Shared;

public class ApiResponse
{
    public bool IsSuccess { get; set; } = false;
    public object? Result { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> Errors { get; set; } = new();
}
