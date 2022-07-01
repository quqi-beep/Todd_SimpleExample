using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Application.Context
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ToddExampleContext _context;
        public Repository(ToddExampleContext context)
        {
            _context = context;
        }
        public Repository()
        {

        }

        public T Insert(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            var env = await _context.AddAsync(entity);
            return env.Entity;
        }

        public void Delete(int Id)
        {
            _context.Remove(Id);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public Task DeleteAsync(int Id)
        {
            _context.Remove(Id);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public T FirstOrDefault(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<T> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public List<T> GetAllList()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllList(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public async Task<List<T>> GetAllListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllListAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public T Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }

        public Task<T> UpdateAsync(T entity)
        {
            var env = _context.Set<T>().Update(entity).Entity;
            return Task.FromResult(env); ;
        }
    }
}
