using System.Runtime.Serialization;

namespace NexBusiness.Validation.Core
{
	public interface IValidationError
	{
		[DataMember]
		ErrorType ErrorType { get; set; }

		[DataMember]
		string Message { get; set; }
		
		[DataMember]
		string Property { get; set; }
	}
}