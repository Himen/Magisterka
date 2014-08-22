using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Core.BasicContract;
using System.Linq.Expressions;
using NHibernate.Linq;
using System.Reflection;

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

        /// <summary>
        /// To trzeba wstrzyknac w Ninject z NHContext
        /// </summary>
        /// <param name="_session"></param>
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

        /// <summary>
        /// Trzeba jeszcze zapewnic zeby byly pobierane tylko te dane, ktorych Data State jest 1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(TKey id)
        {
            return session.Get<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("DataState");
            propertyInfo.SetValue(entity, Convert.ChangeType(0, propertyInfo.PropertyType), null);

            propertyInfo = entity.GetType().GetProperty("EditDate");
            propertyInfo.SetValue(entity, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);

            session.SaveOrUpdate(entity);
        }

        public void RemoveById(TKey id)
        {
            TEntity entity = session.Get<TEntity>(id);

            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("DataState");
            propertyInfo.SetValue(entity, Convert.ChangeType(0, propertyInfo.PropertyType), null);

            propertyInfo = entity.GetType().GetProperty("EditDate");
            propertyInfo.SetValue(entity, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);

            session.SaveOrUpdate(entity);
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

            PropertyInfo propertyInfo = entity.GetType().GetProperty("EditDate");
            propertyInfo.SetValue(entity, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);

            session.SaveOrUpdate(entity);
        }


        public void RemoveFinaly(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            session.Delete(entity);
        }

        public void RemoveFinalyById(TKey id)
        {
            TEntity entity = session.Get<TEntity>(id);

            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            RemoveFinaly(entity);
        }


        public void Attach(ref TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
