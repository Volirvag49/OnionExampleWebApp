using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain.Model;
using Domain.Interfaces;
using System.Linq;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        protected AppDbContext dbContext;
        // используется использовать с любой сущностью
        protected DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.dbContext = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        // Реализация IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
