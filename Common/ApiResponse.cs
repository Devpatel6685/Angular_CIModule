using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CIPLATFORM.Common
{
    public class ApiResponse
    {
        public ApiResponse() => this.Code = (int)HttpStatusCode.OK;

        public ApiResponse(HttpStatusCode code, List<string> messages)
        {
            this.Code = (int)code;
            this.Messages = messages;
        }

        public ApiResponse(HttpStatusCode code, List<string> messages, dynamic data)
        {
            this.Code = (int)code;
            this.Messages = messages;
            this.Data = data;
        }

        public int Code { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public dynamic Data { get; set; }
    }
}