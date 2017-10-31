using System;
using System.Collections.Generic;
using Domain.Model;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        // Получить все записи
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();  

        // Создать запись
        void Create(T entity);

        // Получить запись по id
        T GetById(int? id);
        Task<T> GetByIdAsyn(int? id);

        // Обновить запись
        void Update(T entity);

        // Удалить запись
        void Delete(T entity);
    }
}
