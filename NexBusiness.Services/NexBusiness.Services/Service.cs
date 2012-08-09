using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NexBusiness.Services
{
	public class Service<TEntity, TDbContext> : IService<TEntity>
		where TEntity : class
		where TDbContext : DbContext
	{

		protected TDbContext DbContext { get; set; }

		public Service(DbContext dbContext)
		{
			DbContext = (TDbContext)dbContext;
			DbContext.Configuration.LazyLoadingEnabled = true;
			DbContext.Configuration.AutoDetectChangesEnabled = true;
		}

		public IQueryable<TEntity> All()
		{
			return Set();
		}

		public TEntity ByKey(Expression<Func<TEntity, bool>> predicate)
		{
			return All().FirstOrDefault(predicate);
		}

		public TEntity Add(TEntity entity)
		{
			Set().Add(entity);
			DbContext.SaveChanges();
			return entity;
		}

		public TEntity Update(TEntity entity)
		{
			var entry = DbContext.Entry(entity);
			if (entry == null)
				entity = Set().Attach(entity);
			DbContext.SaveChanges();
			return entity;
		}

		public void Delete(TEntity entity)
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

	public class Service<TEntity, TDbContext, TValidation> : Service<TEntity, TDbContext>, IService<TEntity, TValidation, TDbContext>
		where TEntity : class
		where TDbContext : DbContext
		where TValidation : IValidatator<TEntity, TDbContext>, new()
	{
		protected TValidation Validator { get; set; }

		public Service(DbContext dbContext)
			: base(dbContext)
		{
			Validator = new TValidation { DbContext = DbContext };
		}
	}
}
