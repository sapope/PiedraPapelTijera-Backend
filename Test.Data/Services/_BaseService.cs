using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Repositories.Interfaces;
using Test.Data.Services.Interfaces;
using Test.Data.Tools;
using Test.Entities.DTO;

namespace Test.Data.Services
{
    public class _BaseService : _IBaseService
    {

    } 
    public class _BaseService<T>:_BaseService,_IBaseService<T>
        where T : class
    {
        protected readonly _IBaseRepository<T> _repository;

        public _BaseService(_IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual ResultOperation<T> GetByKey(int id)
        {
            return WraperHelper.WrapOperation((param) => {
                return _repository.GetByKey(param);
            },id);
        }
        public virtual ResultOperation<List<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return WraperHelper.WrapOperation((param) => {
                return _repository.GetAll(param).ToList();
            }, predicate);
        }
        public virtual ResultOperation<int> Add(T entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {
                return _repository.Add(param);
            },entity);
        }
        public virtual ResultOperation<int> Update(T entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {
                return _repository.Update(param);
            }, entity);
        }
        public virtual ResultOperation<int> Delete(T entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {
                return _repository.Delete(param);
            }, entity);
        }
        public virtual ResultOperation<int> DeleteByKey(int id)
        {
            return WraperHelper.WrapOperation((param) =>
            {
                return _repository.DeleteByKey(param);
            }, id);
        }

        public async virtual Task<ResultOperation<T>> GetByKeyAsync(int id)
        {
            return await WraperHelper.WrapOperationAsync(async(param) =>
            {
                return await _repository.GetByKeyAsync(param);
            }, id);
        }
        public async virtual Task<ResultOperation<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await  WraperHelper.WrapOperationAsync( async (param) => {
                return  await _repository.GetAllAsync(param);
            }, predicate);
        }
        public async virtual Task<ResultOperation<int>> AddAsync(T entity)
        {
            return await WraperHelper.WrapOperationAsync(async(param) =>
            {
                return await _repository.AddAsync(param);
            }, entity);
        }
        public async virtual Task<ResultOperation<int>> UpdateAsync(T entity)
        {
            return await WraperHelper.WrapOperationAsync(async(param) =>
            {
                return await _repository.UpdateAsync(param);
            }, entity);
        }
        public async virtual Task<ResultOperation<int>> DeleteAsync(T entity)
        {
            return await WraperHelper.WrapOperationAsync(async (param) =>
            {
                return await _repository.DeleteAsync(param);
            }, entity);
        }
        public async virtual Task<ResultOperation<int>> DeleteByKeyAsync(int id)
        {
            return await WraperHelper.WrapOperationAsync(async(param) =>
            {
                return await _repository.DeleteByKeyAsync(param);
            }, id);
        }
    }
}
