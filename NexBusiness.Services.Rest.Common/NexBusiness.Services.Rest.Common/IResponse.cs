namespace NexBusiness.Services.Rest.Common
{
    public interface IResponse<T> : IBasicResponse
    {
        T Result { get; set; }
    }
}
