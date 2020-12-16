using Microsoft.EntityFrameworkCore;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Infrastructure.Model;
using ProxyBanken.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<int> CountAsync()
        {
            return await _entities.CountAsync();
        }
        public int SaveChanges()
        {
            try
            {

                return _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //Thread.Sleep(10000);
                //return SaveChanges();
                return -1;
            }

        }

        public int Insert(T entity)
        {
            _entities.Add(entity);
            return SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
