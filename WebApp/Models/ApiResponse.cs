using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode httpStatusCode, ApiResponseType apiResponseType, string message)
        {
            HttpStatusCode = httpStatusCode;
            ApiResponseType = apiResponseType;
            Message = message;
        }
        public HttpStatusCode HttpStatusCode { get; set; }
        public ApiResponseType ApiResponseType { get; set; }
        public string Message { get; set; }
    }

    public enum ApiResponseType
    {
        Success = 1,
        Warning = 2,
        Error = 3
    }
}
