using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace NexBusiness.Validation.Core
{
	[DataContract]
	public class ValidationError : IValidationError
	{
		public ValidationError()
		{
		}

		public ValidationError(string property)
			: this(property, string.Format("{0} is required.", Regex.Replace(property, "(\\B[A-Z])", " $1")))
		{
		}

		public ValidationError(string property, string message, ErrorType errorType = ErrorType.Validation)
		{
			Property = property;
			Message = message;
			ErrorType = errorType;
		}
	
		[DataMember]
		public ErrorType ErrorType { get; set; }

		[DataMember]
		public string Message { get; set; }

		[DataMember]
		public string Property { get; set; }
	}
}