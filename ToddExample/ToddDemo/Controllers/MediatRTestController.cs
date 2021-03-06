﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToddDemo.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToddDemo.Controllers
{
    /// <summary>
    /// 测试MediatR的使用
    /// </summary>
    [Route("[controller]")]
    public class MediatRTestController : AuthController
    {
        private readonly MediatRTestService _mediatRTestService;

        public MediatRTestController(MediatRTestService mediatRTestService)
        {
            _mediatRTestService = mediatRTestService;
        }

        /// <summary>
        /// 单播有返回值
        /// </summary>
        /// <returns></returns>
        [HttpPost("mediatr/adduser"), AllowAnonymous]
        public async Task<IActionResult> MediatRAddUserAsync()
        {
            var res = await _mediatRTestService.MediatRAddUserAsync();
            return Ok(res);
        }

        /// <summary>
        /// 单播无返回值
        /// </summary>
        /// <returns></returns>
        [HttpPost("mediatr/void/adduser"), AllowAnonymous]
        public async Task MediatRVoidAddUserAsync()
        {
            await _mediatRTestService.MediatRVoidAddUserAsync();
        }

        /// <summary>
        /// 多播传递
        /// </summary>
        /// <returns></returns>
        [HttpPost("mediatr/notfication/adduser"), AllowAnonymous]
        public async Task MediatRNotifcationAddUserAsync()
        {
            await _mediatRTestService.MediatRNotifcationAddUserAsync();
        }
    }
}
