using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Protocol.Requests;
using ToddDemo.Protocol.Responses;

namespace ToddDemo.Protocol.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task AddUserAsync(UserRequest request);
        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <returns></returns>
        Task<UserResponse> GetUserFirstOrDefaultAsync();
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task<UsersResponse> GetUsersAsync();
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task PatchUserAsync(JsonPatchDocument<UserRequest> request);
    }
}
