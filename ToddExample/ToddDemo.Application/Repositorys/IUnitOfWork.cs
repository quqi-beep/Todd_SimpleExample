using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Application.Repositorys
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
