﻿namespace GiftNotation.Services.UniversalService
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task Create(T entity);

        Task<bool> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
