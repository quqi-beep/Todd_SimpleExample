using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToddDemo.Protocol.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToddDemo.Controllers
{
    /// <summary>
    /// 测试MediatR的使用
    /// </summary>
    [Route("mediatr")]
    public class MediatRTestController : AuthController
    {
        private readonly IMediatRTestService _mediatRTestService;

        public MediatRTestController(IMediatRTestService mediatRTestService)
        {
            _mediatRTestService = mediatRTestService;
        }

        /// <summary>
        /// 单播有返回值
        /// </summary>
        /// <returns></returns>
        [HttpPost("adduser"), AllowAnonymous]
        public async Task<IActionResult> MediatRAddUserAsync()
        {
            var res = await _mediatRTestService.MediatRAddUserAsync();
            return Ok(res);
        }

        /// <summary>
        /// 单播无返回值
        /// </summary>
        /// <returns></returns>
        [HttpPost("void/adduser"), AllowAnonymous]
        public async Task MediatRVoidAddUserAsync()
        {
            await _mediatRTestService.MediatRVoidAddUserAsync();
        }

        /// <summary>
        /// 多播传递
        /// </summary>
        /// <returns></returns>
        [HttpPost("notfication/adduser"), AllowAnonymous]
        public async Task MediatRNotifcationAddUserAsync()
        {
            await _mediatRTestService.MediatRNotifcationAddUserAsync();
        }
    }
}
