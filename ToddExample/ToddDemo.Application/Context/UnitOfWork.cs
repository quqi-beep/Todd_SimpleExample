using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;

namespace ToddDemo.Application.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToddExampleContext _context;

        public UnitOfWork(ToddExampleContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
