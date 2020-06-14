using ProxyBanken.DataAccess.Entity;
using System.Collections.Generic;

namespace ProxyBanken.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        int Insert(T entity);
        int Count();
        int Delete(int id);
        int SaveChanges();
    }
}
