using System.Net;
using System.Runtime.CompilerServices;

namespace CustomerLocationRPApi.Models
{
    public class Response
    {

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } 

        String message;
        public Response(HttpStatusCode httpStatusCode,String msg) 
        {
            this.StatusCode = httpStatusCode;   
            this.Message = msg;
        }

        
    }
}
