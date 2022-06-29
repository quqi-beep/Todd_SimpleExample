using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ToddDemo.Protocol.IService;
using ToddDemo.Protocol.Requests;

namespace ToddDemo.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [Route("home")]
    public class HomeController : AuthController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
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
        [HttpGet("index3"), AllowAnonymous]
        public IActionResult Index3()
        {
            var user = _userService.GetUserFirstOrDefaultAsync();
            return Ok(user);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns></returns>
        [HttpGet("users"), AllowAnonymous]
        public IActionResult GetUsersAsync()
        {

            var users = _userService.GetUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("user/add"), AllowAnonymous]
        public async Task AddUserAsync([FromBody] UserRequest request)
        {
            await _userService.AddUserAsync(request);
        }

        /// <summary>
        /// 更新用户部分信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("user/patch"), AllowAnonymous]
        public void PatchUserAsync([FromBody] JsonPatchDocument<UserRequest> request)
        {
            _userService.PatchUserAsync(request);
        }



    }
}