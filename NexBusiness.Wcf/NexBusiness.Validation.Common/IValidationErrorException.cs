using System.Collections.Generic;

namespace NexBusiness.Validation.Core
{
	public interface IValidationErrorException
	{
		IEnumerable<ValidationError> ValidationErrors { get; set; }
	}
}