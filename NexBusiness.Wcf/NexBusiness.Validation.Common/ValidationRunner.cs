using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NexBusiness.Validation.Core;

public static class ValidationExtensions
{
	private static IEnumerable<ValidationResult> ValidateEntity<T>(this T entity)
	{
		var results = new List<ValidationResult>();
		var context = new ValidationContext(entity, null, null);
		Validator.TryValidateObject(entity, context, results, true);
		return results;
	}

	public static IEnumerable<ValidationError> Validate<T>(this T entity)
	{
		var validationResult = ValidateEntity(entity);
		return
			from result
				in validationResult
			from memberName in result.MemberNames
			select new ValidationError(memberName, result.ErrorMessage);
	}
}
