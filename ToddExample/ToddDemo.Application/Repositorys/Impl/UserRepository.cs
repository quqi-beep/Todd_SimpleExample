using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;

namespace ToddDemo.Application.Repositorys.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToddExampleContext spmContext) : base(spmContext)
        {
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await base.GetAll();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await base.GetEntity(x=>x.UserId==id);
        }
    }
}
