using System.Net;
using NexBusiness.Services.Rest.Common;

namespace NexBusiness.Services.Rest.Core
{
    public class Response<T> : IResponse<T>
    {
        public T Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}