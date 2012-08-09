using System;
using System.Linq;
using System.Transactions;
using NexBusiness.Repositories.RavenDb.Common;
using Raven.Client;

namespace NexBusiness.Repositories.RavenDb.Core
{
    public abstract class AbstractRavenRepository<T> : IRepository<T>
    {
        protected IDocumentStore DocumentStore { get; private set; }

        protected AbstractRavenRepository(IDocumentStore documentStore)
        {
            DocumentStore = documentStore;
        }

        public IQueryable<T> All()
        {
            using (var ds = DocumentStore.OpenSession())
                return ds.Query<T>();
        }
        public T ById(string id)
        {
            using (var ds = DocumentStore.OpenSession())
                return ds.Load<T>(id);
        }

        public T ById(ValueType valueType)
        {
            using (var ds = DocumentStore.OpenSession())
                return ds.Load<T>(valueType);
        }

        public T Save(T entity)
        {
            using (var transaction = new TransactionScope())
            using (var ds = DocumentStore.OpenSession())
            {
                ds.Store(entity);
                ds.SaveChanges();
                transaction.Complete();
                return entity;
            }
        }

        public void Delete(string id)
        {
            using (var transaction = new TransactionScope())
            using (var ds = DocumentStore.OpenSession())
            {
                var entity = ds.Load<T>(id);
                ds.Delete(entity);
                ds.SaveChanges();
                transaction.Complete();
            }
        }
    }
}
