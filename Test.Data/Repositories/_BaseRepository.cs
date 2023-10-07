using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories
{
    public class _BaseRepository : _IBaseRepository { }
    public class _BaseRepository<T> : _BaseRepository, _IBaseRepository<T>
        where T : class
    {
        protected readonly DbContext objContext;
        protected DbSet<T> objSet;

        public _BaseRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Empty Context");

            if (context.Database.ProviderName.ToLowerInvariant().Contains("sqlite"))
            {
                context.Database.EnsureCreated();
            }

            objContext = context;
            objSet = context.Set<T>();
        }


        public virtual T GetByKey(int id)
        {
            try
            {

                return objSet.Find(id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = objSet;
            if (predicate == null)
            {
                predicate = item => item != null;
            }
            return query.Where(predicate);
        }

        public virtual int Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");


                objSet.Add(entity);
                return objContext.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual int Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");



                if (objContext.Entry(entity).State == EntityState.Detached)
                {
                    objSet.Attach(entity);
                }
                objContext.Entry(entity).State = EntityState.Modified;
                return objContext.SaveChanges();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual int Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");



                if (objContext.Entry(entity).State == EntityState.Detached)
                {
                    objSet.Attach(entity);
                }
                objContext.Entry(entity).State = EntityState.Deleted;
                return objContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public virtual int DeleteByKey(int id)
        {
            return Delete(GetByKey(id));
        }

        public async virtual Task<T> GetByKeyAsync(int id)
        {
            try
            {

                return await objSet.FindAsync(id);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = objSet;
            if (predicate == null)
            {
                predicate = item => item != null;
            }
             return await query.Where(predicate).ToListAsync();
               
        }

        public async virtual Task<int> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");


                await objSet.AddAsync(entity);
                return await objContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async virtual Task<int> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");



                if (objContext.Entry(entity).State == EntityState.Detached)
                {
                    objSet.Attach(entity);
                }
                objContext.Entry(entity).State = EntityState.Modified;
                return await objContext.SaveChangesAsync();



            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async virtual Task<int> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Empty entity");



                if (objContext.Entry(entity).State == EntityState.Detached)
                {
                    objSet.Attach(entity);
                }
                objContext.Entry(entity).State = EntityState.Deleted;
                return await objContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async virtual Task<int> DeleteByKeyAsync(int id)
        {
            return await DeleteAsync(await GetByKeyAsync(id));
        }
    }
}
