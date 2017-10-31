using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain.Model;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : BaseEntity
    {
        protected AppDbContext dbContext;
        protected DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.dbContext = context;
            dbSet = context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetByIdAsyn(int? id)
        {
            return  await dbSet.FindAsync(id);
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
