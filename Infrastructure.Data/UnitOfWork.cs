using System;
using Domain.Model;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        // контекст данных
        private AppDbContext dbContext = new AppDbContext();

        // Приватные члены
        private Repository<Book> bookRepository;
        private Repository<Reader> readerRepository;

        // Паттерн синглтон для каждого репозитория
        public IRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new Repository<Book>(dbContext);
                }
                return bookRepository;
            }

        }

        public IRepository<Reader> ReaderRepository
        {
            get
            {
                if (readerRepository == null)
                {
                    readerRepository = new Repository<Reader>(dbContext);
                }
                return readerRepository;
            }

        }

        // Сохранение всех изменений в репозиториях
        public void Commit()
        {
            dbContext.SaveChanges();
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
