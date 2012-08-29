using System.Net;

namespace NexBusiness.Services.Rest.Common
{
    public interface IBasicResponse
    {
        HttpStatusCode StatusCode { get; set; }
        string Message { get; set; }
    }
}