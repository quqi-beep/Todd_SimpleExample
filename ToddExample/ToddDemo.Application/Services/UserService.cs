﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;
using ToddDemo.Application.EventHandlers.Event;
using ToddDemo.Application.Repositorys;
using ToddDemo.Protocol.IService;
using ToddDemo.Protocol.Requests;
using ToddDemo.Protocol.Responses;

namespace ToddDemo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ToddExampleContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ToddExampleContext context,
            IUserRepository userRepository,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _context = context;
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

            var text = _context.Set<User>();
            var first = text.FirstOrDefault();
            if (first != null)
            {
                res.UserId = first.UserId;
                res.UserName = first.UserName;
                res.Password = first.Password;
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
            var list = await _userRepository.GetAllUserAsync();
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
            await _context.AddAsync(user);
            //await _context.SaveChangesAsync();
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 补丁更新
        /// </summary>
        /// <param name="request"></param>
        public async Task PatchUserAsync(JsonPatchDocument<UserRequest> request)
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
            await Task.Run(() => { });
        }

    }
}
