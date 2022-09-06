using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Models
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = "", object result = null)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;

        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public object Result { get; set; }
    }
}
