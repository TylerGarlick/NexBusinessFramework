using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace NexBusiness.Services
{
	public interface IService<TEntity> where TEntity : class
	{
		IQueryable<TEntity> All();
		TEntity ByKey(Expression<Func<TEntity, bool>> predicate);
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Delete(TEntity entity);
	}

	public interface IService<TEntity, TValidation, TDbContext> :
		IService<TEntity>
		where TEntity : class
		where TValidation : IValidatator<TEntity, TDbContext>
		where TDbContext : DbContext
	{

	}

	public interface IValidatator<in TEntity, TDbContext> where TDbContext : DbContext
	{
		TDbContext DbContext { get; set; }
		IEnumerable<Error> Validate(TEntity entity);
		bool IsValid { get; }
	}

	public class PersonValidator : Validator<Person, DbContext>, IValidatator<Person, DbContext>
	{
		public override IEnumerable<Error> Validate(Person entity)
		{

			return base.Validate(entity);
		}
	}

	public class Person
	{

	}
}