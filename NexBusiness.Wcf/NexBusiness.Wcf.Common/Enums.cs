using System.Runtime.Serialization;

namespace NexBusiness.Wcf.Common
{
	[DataContract]
	public enum ResponseType
	{
		[EnumMember]
		Unknown = 0,
		[EnumMember]
		Success,
		[EnumMember]
		Error,
		[EnumMember]
		Exception
	}
}