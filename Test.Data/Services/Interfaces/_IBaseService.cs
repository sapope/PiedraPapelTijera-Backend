using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.DTO;

namespace Test.Data.Services.Interfaces
{
    public interface _IBaseService
    {
    }
    public interface _IBaseService<T>:_IBaseService
        where T:class
    {
        ResultOperation<T> GetByKey(int id);
        ResultOperation<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        ResultOperation<int> Add(T entity);
        ResultOperation<int> Update(T entity);
        ResultOperation<int> Delete(T entity);
        ResultOperation<int> DeleteByKey(int id);
        Task<ResultOperation<T>> GetByKeyAsync(int id);
        Task<ResultOperation<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<ResultOperation<int>> AddAsync(T entity);
        Task<ResultOperation<int>> UpdateAsync(T entity);
        Task<ResultOperation<int>> DeleteAsync(T entity);
        Task<ResultOperation<int>> DeleteByKeyAsync(int id);
    }
}
