using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Repository.Interface;

namespace ProxyBanken.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _entities;
        public Repository(ApplicationContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T Get(int id)
        {
            return _entities.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T entity)
        {
            _entities.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;           
            return entity;
        }

        public int Count()
        {
            return _entities.Count();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
