using System.Net;
using NexBusiness.Services.Rest.Common;

namespace NexBusiness.Services.Rest.Core
{
    public class BasicResponse : IBasicResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}