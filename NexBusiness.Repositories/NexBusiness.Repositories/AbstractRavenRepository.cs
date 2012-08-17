using System;
using System.Linq;
using System.Transactions;
using NexBusiness.Repositories.RavenDb.Common;
using Raven.Client;

namespace NexBusiness.Repositories.RavenDb.Core
{
    public abstract class AbstractRavenRepository<T> : IRepository<T>, IDisposable
    {
        protected IDocumentStore DocumentStore { get; private set; }
        protected IDocumentSession DocumentSession { get; private set; }
        protected AbstractRavenRepository(IDocumentStore documentStore)
        {
            DocumentStore = documentStore;
            DocumentSession = DocumentStore.OpenSession();
        }

        public IQueryable<T> All()
        {
            return DocumentSession.Query<T>();
        }
        public T ById(string id)
        {
            return DocumentSession.Load<T>(id);
        }

        public T ById(ValueType valueType)
        {
            return DocumentSession.Load<T>(valueType);
        }

        public T Add(T entity)
        {
            using (var transaction = new TransactionScope())
            {
                DocumentSession.Store(entity);
                DocumentSession.SaveChanges();
                transaction.Complete();
                return entity;
            }
        }

        public T Update(T entity)
        {
            using (var transaction = new TransactionScope())
            {
                DocumentSession.SaveChanges();
                transaction.Complete();
                return entity;
            }
        }

        public void Delete(string id)
        {
            using (var transaction = new TransactionScope())
            {
                var entity = DocumentSession.Load<T>(id);
                DocumentSession.Delete(entity);
                DocumentSession.SaveChanges();
                transaction.Complete();
            }
        }

        public void Dispose()
        {
            DocumentSession.Dispose();
        }
    }
}
