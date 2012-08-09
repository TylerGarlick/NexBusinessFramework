using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NexBusiness.Repositories.Testing
{
	public abstract class FakeRepository<T>
	{
		public List<T> Data { get; private set; }
		public bool UpdateCalled { get; set; }
		public bool AddCalled { get; set; }

		protected FakeRepository()
		{
			UpdateCalled = false;
			AddCalled = false;


			Data = new List<T>();
			Data.AddRange(SetupFakeData());
		}

		public abstract IEnumerable<T> SetupFakeData();

		public IQueryable<T> All()
		{
			return Data.AsQueryable();
		}

		public T ByKey(Expression<Func<T, bool>> predicate)
		{
			return All().FirstOrDefault(predicate);
		}

		public void Delete(T entity)
		{
			Data.Remove(entity);
		}

		public T Update(T entity)
		{
			UpdateCalled = true;
			return entity;
		}

		public T Add(T entity)
		{
			AddCalled = true;
			Data.Add(entity);
			return entity;
		}
	}
}
