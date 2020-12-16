using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Application.Repositorys
{
    public interface IBaseRepository<T> where T : class
    {
        void Update(T entity);

        Task<int> Update(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity);

        Task<int> Delete(Expression<Func<T, bool>> whereLambda);

        Task<bool> IsExist(Expression<Func<T, bool>> whereLambda);

        Task<T> GetEntity(Expression<Func<T, bool>> whereLambda);

        Task<List<T>> GetAll();

        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> whereLambda);
    }
}
