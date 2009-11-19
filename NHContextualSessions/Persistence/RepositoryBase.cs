namespace Persistence {
    using System;
    using System.Collections.Generic;
    using Domain;
    using NHibernate;
    using NHibernate.Criterion;

    public class RepositoryBase<TEntity> : ICRUDRepository<TEntity>
        where TEntity : EntityBase, new() {

        protected readonly ISessionBuilder _sessionBuilder;

        public RepositoryBase(ISessionBuilder sessionFactory) {
            _sessionBuilder = sessionFactory;
        }

        #region ICRUDRepository<TEntity> Members

        public void Create(TEntity entity) {
            ISession session = GetSession();
            using (ITransaction transaction = session.BeginTransaction()) {
                session.Save(entity);

                transaction.Commit();
            }
        }

        public TEntity Retrieve(Guid entityId) {
            ISession session = GetSession();
            ICriteria criteria = session.CreateCriteria(typeof(TEntity));
            criteria.Add(Expression.Eq("Id", entityId));

            return criteria.UniqueResult<TEntity>();
        }

        public IList<TEntity> RetrieveAll() {
            ISession session = GetSession();
            ICriteria targetObjects = session.CreateCriteria(typeof(TEntity));

            return targetObjects.List<TEntity>();
        }

        public void Update(TEntity entity) {
            ISession session = GetSession();

            using (ITransaction transaction = session.BeginTransaction()) {
                session.Update(entity);

                transaction.Commit();
            }
        }

        public void Delete(TEntity entity) {
            ISession session = GetSession();
            using (ITransaction transaction = session.BeginTransaction()) {
                session.Delete(entity);


                transaction.Commit();
            }
        }

        #endregion

        protected ISession GetSession() {
            return _sessionBuilder.CurrentSession;
        }
    }
}