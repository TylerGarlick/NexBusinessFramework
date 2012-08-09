using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NexBusiness.Repositories.Common;

namespace NexBusiness.Repositories.EntityFramework
{
	public class Repository<TEntity, TDbContext> : IRepository<TEntity>
		where TEntity : class
		where TDbContext : DbContext
	{

		protected TDbContext DbContext { get; set; }

		public Repository(DbContext dbContext)
		{
			DbContext = (TDbContext)dbContext;
		}

		public virtual IQueryable<TEntity> All()
		{
			return Set();
		}

		public virtual TEntity ByKey(Expression<Func<TEntity, bool>> predicate)
		{
			return All().FirstOrDefault(predicate);
		}

		public virtual TEntity Add(TEntity entity)
		{
			Set().Add(entity);
			DbContext.SaveChanges();
			return entity;
		}

		public virtual TEntity Update(TEntity entity)
		{
			var entry = DbContext.Entry(entity);
			if (entry == null)
				entity = Set().Attach(entity);
			DbContext.SaveChanges();
			return entity;
		}

		public virtual void Delete(TEntity entity)
		{
			var entry = DbContext.Entry(entity);

			if (entry != null)
				entry.State = EntityState.Deleted;
			else
				Set().Attach(entity);

			DbContext.Entry(entity).State = EntityState.Deleted;
			DbContext.SaveChanges();
		}

		private DbSet<TEntity> Set()
		{
			return DbContext.Set<TEntity>();
		}
	}
}
