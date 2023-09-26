using System.Net;

namespace TaskManager.Application.Abstractions.ResponseModels
{
    public class QueryHandlerRespnse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public long? TotalCount { get; set; }
        public string? ErrorMessage { get; set; }

        public void SetSuccess(T data, long? totalCount = null)
        {
            Data = data;
            Success = true;
            StatusCode = HttpStatusCode.OK;
            TotalCount = totalCount;
        }

        public void SetResponseError(string errorMessage, HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            Success = false;
            StatusCode = statusCode;
        }
    }
}
