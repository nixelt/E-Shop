﻿namespace E_Shop.Data.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// A generic repository interface that exposes a standard set of methods for performing CRUD operations on entities within the system.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(long id);

        T GetById(string id);

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
