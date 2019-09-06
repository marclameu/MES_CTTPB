using System;
using System.Collections.Generic;
using System.Text;

namespace CTTPB.MESCDP.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void EvictIfExists(T entity);
    }
}
