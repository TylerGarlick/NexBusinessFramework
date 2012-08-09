using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using NexBusiness.Validation.Core;

public static class DbEntityValidationExceptionExtensions
{
	public static List<IValidationError> GetErrorsFromException(this DbEntityValidationException exception)
	{
		return exception.EntityValidationErrors.Select(dbError => dbError.ValidationErrors.Select(e => new ValidationError()
																									   {
																										   Message = e.ErrorMessage,
																										   Property = e.PropertyName,
																										   ErrorType = ErrorType.Validation
																									   })).Cast<IValidationError>().ToList();
	}
}
