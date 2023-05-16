using HotelManagmnet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Contracts.Persistence
{
    public interface IGenericRepository<T>where T : class
    {
        Task<T> GetAsync();
        Task<T> GetById(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
    }
}
