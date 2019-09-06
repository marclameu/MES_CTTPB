using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.DOMAIN;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Util;

namespace CTTPB.MESCDP.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ISession Session => NHibernateHelper.Session;

        public IEnumerable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public int Create(T entity)
        {
            var id = (int)Session.Save(entity);
            Session.Flush();
            return id;
        }

        public void Update(T entity)
        {
            Session.Update(entity);
            Session.Flush();
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public virtual void EvictIfExists(T entity)
        {
            if (Session.Contains(entity))
                Session.Evict(entity);
        }


        /// <summary>
        ///     Loads all the entities that match the criteria
        ///     by order
        /// </summary>
        /// <param name="criteria">the criteria to look for</param>
        /// <param name="pageInfo">the pagination information</param>
        /// <returns>All the entities that match the criteria</returns>
        public IList<T> FindAll(ICriteria criteria, PaginationInfo<T> pageInfo)
        {
            var crit = ExecutableCriteria(criteria, pageInfo);
            return crit.List<T>();
        }

        public virtual IList<T> FindAll(DetachedCriteria criteria)
        {
            ICriteria crit = ExecutableCriteria<T>(criteria);
            return crit.List<T>();
        }

        public ICriteria ExecutableCriteria<T>(ICriteria criteria)
        {
            return ExecutableCriteria<T>(criteria);
        }

        public ICriteria ExecutableCriteria<T>(DetachedCriteria criteria)
        {
            return ExecutableCriteria<T>(criteria, null, null);
        }

        public ICriteria ExecutableCriteria<T>(ICriteria criteria, PaginationInfo<T> pageInfo)
        {
            return ExecutableCriteria(criteria, pageInfo, null);
        }
        private ICriteria GetExecutableCriteriaFromClone(DetachedCriteria criteria)
        {
            byte[] clone = SerializationHelper.Serialize(criteria);
            var crit = (DetachedCriteria)SerializationHelper.Deserialize(clone);
            return crit.GetExecutableCriteria(Session);
        }
        public ICriteria ExecutableCriteria<T>(DetachedCriteria criteria, PaginationInfo<T> pageInfo,
            params Order[] orders)
        {
            ICriteria crit = criteria != null
                ? GetExecutableCriteriaFromClone(criteria)
                : Session.CreateCriteria(typeof(T));
            if (pageInfo != null)
            {
                int firstResult = ((pageInfo.Page - 1) * pageInfo.PageSize);
                int numberOfResults = pageInfo.PageSize;
                crit.SetFirstResult(firstResult).SetMaxResults(numberOfResults);
                if (pageInfo.SortIndex != null)
                    crit.AddOrder(new Order(pageInfo.SortIndex, "asc".Equals(pageInfo.SortDirection)));
            }

            if (orders != null)
                orders.Select(o => crit.AddOrder(o));

            return crit;
        }

        public ICriteria ExecutableCriteria<T>(ICriteria criteria, PaginationInfo<T> pageInfo,
            params Order[] orders)
        {
            var crit = criteria == null ? Session.CreateCriteria(typeof(T)) : criteria;
            if (pageInfo != null)
            {
                var firstResult = (pageInfo.Page - 1) * pageInfo.PageSize;
                var numberOfResults = pageInfo.PageSize;
                crit.SetFirstResult(firstResult).SetMaxResults(numberOfResults);
                if (pageInfo.SortIndex != null)
                    crit.AddOrder(new Order(pageInfo.SortIndex, "asc".Equals(pageInfo.SortDirection)));
            }

            if (orders != null)
                orders.Select(o => crit.AddOrder(o));

            return crit;
        }

        public virtual long Count(ICriteria iCriteria)
        {
            return Count(iCriteria, Projections.RowCount());
        }

        private long Count(ICriteria iCriteria, IProjection projection)
        {
            iCriteria.SetProjection(projection);
            var countMayBeInt32OrInt64DependingOnDatabase = iCriteria.UniqueResult();
            return Convert.ToInt64(countMayBeInt32OrInt64DependingOnDatabase);
        }

        protected DetachedCriteria CreateCriteria()
        {
            return DetachedCriteria.For(typeof(T));
        }
    }
}
