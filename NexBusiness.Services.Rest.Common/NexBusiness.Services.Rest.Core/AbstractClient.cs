using System;
using System.Net.Http;

namespace NexBusiness.Services.Rest.Core
{
    public abstract class AbstractClient
    {
        protected string BaseUrl { get; private set; }
        protected HttpClient HttpClient { get; private set; }

        protected AbstractClient(string baseUrl)
        {
            BaseUrl = baseUrl;
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        protected AbstractClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}
