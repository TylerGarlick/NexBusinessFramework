using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NexBusiness.Validation.Core
{
	[DataContract]
	public class ValidationErrorException : Exception, IValidationErrorException
	{
		[DataMember]
		public IEnumerable<ValidationError> ValidationErrors { get; set; }

		public ValidationErrorException()
			: base("Validation error has occurred")
		{
		}

		public ValidationErrorException(IEnumerable<ValidationError> validationErrors)
			: base("Valiation Error has occurred")
		{
			ValidationErrors = validationErrors;
		}
	}
}
