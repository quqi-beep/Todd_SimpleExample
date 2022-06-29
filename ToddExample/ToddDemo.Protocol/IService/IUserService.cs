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

        Task AddUserAsync(UserRequest request);
        Task<UserResponse> GetUserFirstOrDefaultAsync();

        Task<UsersResponse> GetUsersAsync();

        Task PatchUserAsync(JsonPatchDocument<UserRequest> request);
    }
}
