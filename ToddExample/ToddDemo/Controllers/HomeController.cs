using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToddDemo.Application.Requests;
using ToddDemo.Application.Services;

namespace ToddDemo.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HomeController : AuthController
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 测试 Api 1
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        public IActionResult Index()
        {
            var str = "测试 jwt demo";
            return Ok(str);
        }

        /// <summary>
        /// 测试 Api 2
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "v2")]
        [HttpGet("index2")]
        public IActionResult Index2()
        {
            var user = base.CurrentUser;
            var str = "测试 jwt demo2";
            return Ok(new { user.UserId, user.UserName, Message = str });
        }

        /// <summary>
        /// 测试连接mysql
        /// </summary>
        /// <returns></returns>
        [HttpGet("index3"),AllowAnonymous]
        public IActionResult Index3()
        {
            var user = _userService.GetUserAsync();
            return Ok(user);
        }

        [HttpPost("user/add"),AllowAnonymous]
        public async Task AddUserAsync([FromBody]UserRequest request)
        {
            await _userService.AddUserAsync(request);
        }
    }
}