using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Repositories.Interfaces
{
    public interface _IBaseRepository
    {
    }
    public interface _IBaseRepository<T>:_IBaseRepository
        where T : class
    {
        T GetByKey(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int DeleteByKey(int id);
        Task<T> GetByKeyAsync(int id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteByKeyAsync(int id);
    }
}
