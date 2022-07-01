using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;
using ToddDemo.Application.EventHandlers.Event;
using ToddDemo.Protocol.IService;
using ToddDemo.Protocol.Requests;
using ToddDemo.Protocol.Responses;

namespace ToddDemo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IRepository<User> userRepository,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public async Task<UserResponse> GetUserFirstOrDefaultAsync()
        {
            var res = new UserResponse();
            var user = await _userRepository.FirstOrDefaultAsync(x => x.UserId == 1);
            if (user != null)
            {
                res.UserId = user.UserId;
                res.UserName = user.UserName;
                res.Password = user.Password;
            }
            await Task.Run(() => { });
            return res;
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns></returns>
        public async Task<UsersResponse> GetUsersAsync()
        {
            var list = await _userRepository.GetAllListAsync();
            var users = _mapper.Map<List<UserDto>>(list);

            //多Profile映射
            var age = _mapper.Map<List<UserAgeDto>>(users);

            return new UsersResponse { Users = users };
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddUserAsync(UserRequest request)
        {
            var user = new User
            {
                UserId = request.UserId,
                UserName = request.UserName,
                Password = request.Password,
                Age = request.Age
            };
            await _userRepository.InsertAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 补丁更新
        /// </summary>
        /// <param name="request"></param>
        public async Task PatchUserAsync(JsonPatchDocument<UserRequest> request)
        {
            var user =await _userRepository.FirstOrDefaultAsync(x => x.UserId == 1);
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
            await _userRepository.UpdateAsync(user);

            await Task.Run(() => { });
        }

    }
}
