using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;

namespace ToddDemo.Application.Repositorys.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SpmContext _spmContext;

        public UnitOfWork(SpmContext spmContext)
        {
            _spmContext = spmContext;
        }

        public void SaveChanges()
        {
            _spmContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _spmContext.SaveChangesAsync();
        }
    }
}
