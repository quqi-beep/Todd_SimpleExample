using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Application.Repositorys
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();

        Task<User> GetUserAsync(int id);
    }
}
