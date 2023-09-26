using System.Net;

namespace TaskManager.Application.Abstractions.ResponseModels
{
    public class CommandHandlerResponse
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public void SetSuccess()
        {
            Success = true;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = null;
        }

        public void SetResponseError(string errorMessage, HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            Success = false;
            StatusCode = statusCode;
        }
    }
}
