using System;
using System.Linq;
using System.Linq.Expressions;

namespace NexBusiness.Repositories.Common
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> All();
		TEntity ByKey(Expression<Func<TEntity, bool>> predicate);
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		void Delete(TEntity entity);
	}
}