using System.Runtime.Serialization;

namespace NexBusiness.Validation.Core
{
	[DataContract]
	public enum ErrorType
	{
		[EnumMember]
		Unknown = 0,
		[EnumMember]
		Validation,
		[EnumMember]
		Exception
	}
}
