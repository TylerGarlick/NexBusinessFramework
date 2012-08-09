using System.Collections.Generic;
using System.Runtime.Serialization;
using NexBusiness.Validation.Core;

namespace NexBusiness.Wcf.Common
{
	public interface IResponse
	{
		[DataMember]
		ResponseType Type { get; set; }

		[DataMember]
		IEnumerable<IValidationError> Errors { get; set; }

		[DataMember]
		bool IsValid { get; }
	}
}