using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : AuthController
    {

        [HttpGet("index")]
        public IActionResult Index()
        {
            var str = "测试 jwt demo";
            return Ok(str);
        }

        [HttpGet("index2")]
        public IActionResult Index2()
        {
            var user = base.CurrentUser;
            var str = "测试 jwt demo2";
            return Ok(new { user.UserId, user.UserName, Message = str });
        }
    }
}