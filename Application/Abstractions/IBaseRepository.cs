using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(Guid id);

        Task<bool> AddAsync(T toCreate);

        Task<bool> UpdatePersonAsync(T toUpdate);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}