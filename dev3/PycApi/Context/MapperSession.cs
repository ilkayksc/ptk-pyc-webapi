﻿using NHibernate;
using PycApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PycApi.Context
{
    public class MapperSession : IMapperSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Book> Books => session.Query<Book>();


        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(Book entity)
        {
            session.Save(entity);
        }
        public void Update(Book entity)
        {
            session.Update(entity);
        }
        public void Delete(Book entity)
        {
            session.Delete(entity);
        }
    }
}
