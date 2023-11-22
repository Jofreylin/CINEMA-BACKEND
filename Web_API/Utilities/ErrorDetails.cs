using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_API.Utilities
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public List<ErrorDetails> Details { get; set; } = new List<ErrorDetails>();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class ErrorDetails
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
    }

    public class CustomException : Exception
    {
        public string? ClassName { get; set; }
        public string? MethodName { get; set; }
        public int? CreationUserId { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public CustomException(string message, Exception innerException, HttpStatusCode statusCode, string? className, string? methodName, int? creationUserId = null)
            : base(message, innerException)
        {
            ClassName = className;
            MethodName = methodName;
            CreationUserId = creationUserId;
            StatusCode = statusCode;
        }
    }

}
