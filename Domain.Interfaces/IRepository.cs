using System;
using System.Collections.Generic;
using Domain.Model;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        // Получить все записи
        IEnumerable<T> GetAll();

        // Создать запись
        void Create(T entity);

        // Получить запись по id
        T GetById(int? id);

        // Обновить запись
        void Update(T entity);

        // Удалить запись
        void Delete(T entity);
    }
}
