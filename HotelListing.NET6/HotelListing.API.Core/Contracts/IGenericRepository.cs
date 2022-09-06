﻿using HotelListing.API.Models;

namespace HotelListing.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetAsync(int? id); // ? = potentially nullable
        Task<List<T>> GetAllAsync();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity); 
        Task<bool> Exist(int id);

    }
}
