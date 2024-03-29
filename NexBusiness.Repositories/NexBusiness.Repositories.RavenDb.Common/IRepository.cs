﻿using System;
using System.Linq;

namespace NexBusiness.Repositories.RavenDb.Common
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        T ById(string id);
        T ById(ValueType valueType);
        T Add(T entity);
        T Update(T entity);
        void Delete(string id);
    }
}
