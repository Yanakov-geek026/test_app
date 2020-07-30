using Domain;
using NHibernate;
using NHibernate.Persister.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage.Interfaces
{
    public interface IRepository<T> where T : PersistentObject
    {
        T Load(object noteId);

        T Get(long id);

        IQueryable<T> GetAll();

        ISQLQuery ExecuteSqlQuery(string sqlQruery);

        void Add(T entity);

        T AddEntity(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
