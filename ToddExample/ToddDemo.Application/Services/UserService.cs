using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;
using ToddDemo.Application.Requests;
using ToddDemo.Application.Responses;

namespace ToddDemo.Application.Services
{
    public class UserService
    {
        private readonly SpmContext _context;

        public UserService(SpmContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public UserResponse GetUserAsync()
        {
            var res = new UserResponse();

            var text = _context.Set<User>();
            var first = text.FirstOrDefault();
            if (first != null)
            {
                res.UserId = first.UserId;
                res.UserName = first.UserName;
                res.Password = first.Password;
            }
            return res;
        }


        public async Task AddUserAsync(UserRequest request)
        {
            var user = new User
            {
                UserId = request.UserId,
                UserName = request.UserName,
                Password = request.Password,
                Age = request.Age
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public void PatchUserAsync(JsonPatchDocument<UserRequest> request)
        {
            var user = _context.Set<User>().FirstOrDefault();
            var userDbReuqust = new UserRequest
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Age = user.Age
            };
            request.ApplyTo(userDbReuqust);

            user.UserId = userDbReuqust.UserId;
            user.UserName = userDbReuqust.UserName;
            user.Password = userDbReuqust.Password;
            user.Age = userDbReuqust.Age;
          

            _context.Set<User>().Update(user);
            _context.SaveChanges();
        }
    }
}
