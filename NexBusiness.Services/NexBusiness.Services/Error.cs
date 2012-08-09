namespace NexBusiness.Services
{
	public class Error
	{
		public Error(string message, ErrorType errorType)
		{
			Message = message;
			ErrorType = errorType;
		}

		public Error(string message, string property, ErrorType errorType)
			: this(message, errorType)
		{
			Property = property;
		}

		public string Message { get; set; }
		public string Property { get; set; }
		public ErrorType ErrorType { get; set; }
	}
}