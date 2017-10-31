using System;
using Domain.Model;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        // контекст данных
        private AppDbContext dbContext = new AppDbContext();

        // Приватные члены
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Reader> readerRepository;

        // Паттерн синглтон для каждого репозитория
        public IGenericRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new GenericRepository<Book>(dbContext);
                }
                return bookRepository;
            }

        }

        public IGenericRepository<Reader> ReaderRepository
        {
            get
            {
                if (readerRepository == null)
                {
                    readerRepository = new GenericRepository<Reader>(dbContext);
                }
                return readerRepository;
            }

        }

        // Сохранение всех изменений в репозиториях
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        // Реализация интерфейса IDisposible
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
