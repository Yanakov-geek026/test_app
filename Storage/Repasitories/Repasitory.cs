﻿using Domain;
using NHibernate;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage.Repasitories
{
    public class Repository<T> : IRepository<T> where T : PersistentObject, new()
    {
        private readonly ISessionStorage _sessionStorage;

        public Repository(ISessionStorage ss)
        {
            _sessionStorage = ss;
        }

        public Type ElementType => OpenSession().Query<T>().ElementType;

        public IQueryProvider Provider => OpenSession().Query<T>().Provider;

        public T Load(object nodeId)
        {
            return !CheckId(nodeId) ? null : OpenSession().Load<T>(nodeId);
        }

        public ISQLQuery ExecuteSqlQuery(string sqlQuery)
        {
            var session = OpenSession();
            Logger.Logger.WriteLogg("NHibernate", sqlQuery, "info");
            return session.CreateSQLQuery(sqlQuery);
        }

        public T Get(long id)
        {
            var session = OpenSession();
            Logger.Logger.NhibernateSelect<T>(id.ToString());
            var returnVal = session.Get<T>(id);

            return returnVal;
        }

        public IQueryable<T> GetAll()
        {
            var session = OpenSession();
            Logger.Logger.NhibernateSelect<T>("");
            return session.Query<T>();
        }

        public void Add(T entity)
        {
            var session = OpenSession();
            Logger.Logger.NhibernateInsert(entity, "Id");
            using (var transaction = BeginTransaction(session))
            {
                session.Save(entity);
                transaction.Commit();
                session.Flush();
            }
        }

        public T AddEntity(T entity)
        {
            var session = OpenSession();
            long id = -1;
            T result = null;
            Logger.Logger.NhibernateInsert(entity, "Id");
            using (var transaction = BeginTransaction(session))
            {

                id = (long)session.Save(entity);
                transaction.Commit();
                result = session.Get<T>(id);
                session.Flush();
            }

            return result;
        }

        public void Update(T entity)
        {
            var session = OpenSession();
            Logger.Logger.NhibernateUpdate(entity, "Id");
            session.Update(entity);
            session.Flush();
        }

        public void Remove(T entity)
        {

            var session = OpenSession();
            Logger.Logger.NhibernateDelete(entity);
            using (var transaction = BeginTransaction(session))
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public bool CheckId(object id)
        {
            var objectId = id as int?;
            return objectId.HasValue && objectId.Value != 0;
        }

        protected ISession OpenSession()
        {
            return _sessionStorage.Session;
        }

        protected ITransaction BeginTransaction(ISession session)
        {
            return session.BeginTransaction();
        }
    }
}
