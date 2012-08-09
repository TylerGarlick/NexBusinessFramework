using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NexBusiness.Services
{
	public class Validator<TEntity, TDbContext> : IValidatator<TEntity, TDbContext> where TDbContext : DbContext
	{
		public TDbContext DbContext { get; set; }

		public List<Error> Errors { get; private set; }

		public Validator()
		{
			Errors = new List<Error>();
		}

		public virtual IEnumerable<Error> Validate(TEntity entity)
		{
			return Errors;
		}

		public bool IsValid
		{
			get { return !Errors.Any(); }
		}
	}
}