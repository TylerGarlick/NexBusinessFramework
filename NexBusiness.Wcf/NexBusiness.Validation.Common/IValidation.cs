using System.Collections.Generic;

namespace NexBusiness.Validation.Core
{
	public interface IValidation<in TEntity>
	{
		IEnumerable<IValidationError> Validate(TEntity entity, OperationType operationType);
	}
}
