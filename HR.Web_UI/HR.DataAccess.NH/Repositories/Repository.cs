using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Core.BasicContract;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace HR.DataAccess.NH.Repositories
{
    /// <summary>
    /// Bardzo przydatny tutorial do Repo itd
    /// http://blog.gauffin.org/2013/01/repository-pattern-done-right/
    /// </summary>
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        ISession session;

        protected ISession Session { get { return session; } }

        public Repository(ISession _session)
	    {
            session =  _session;
	    }

        public IQueryable<TEntity> GetAll()
        {
            return session.Query<TEntity>();
            
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> pred)
        {
            return session.Query<TEntity>().Where(pred);
        }

        public TEntity GetById(TKey id)
        {
            return session.Get<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);
            
            session.Delete(entity);
        }

        public void RemoveById(TKey id)
        {
            TEntity entity = session.Get<TEntity>(id);

            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            Remove(entity);

        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            session.SaveOrUpdate(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            session.SaveOrUpdate(entity);
        }
    }
}
