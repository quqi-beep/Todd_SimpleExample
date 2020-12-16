using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;

namespace ToddDemo.Application.Repositorys.Impl
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SpmContext _spmContext;
        public BaseRepository(SpmContext spmContext)
        {
            _spmContext = spmContext;
        }

        public void Update(T entity)
        {
            _spmContext.Set<T>().Update(entity);
        }

        public async Task<int> Update(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity)
        {
            var entitys = _spmContext.Set<T>().Where(whereLambda);
            _spmContext.UpdateRange(entitys);
            return await Task.FromResult(entitys.Count());
        }

        public async Task<int> Delete(Expression<Func<T, bool>> whereLambda)
        {
            var entitys = _spmContext.Set<T>().Where(whereLambda);
            _spmContext.RemoveRange(entitys);
            return await Task.FromResult(entitys.Count());
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> whereLambda)
        {
            return await _spmContext.Set<T>().AnyAsync(whereLambda);
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return await _spmContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(whereLambda);
        }

        public async Task<List<T>> GetAll()
        {
            return await _spmContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _spmContext.Set<T>().Where(whereLambda).ToListAsync();
        }

    }
}
