using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToddDemo.Controllers;
using ToddDemo.Protocol.IService;

namespace ToddDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : AuthController
    {
        private readonly ITestService _testService;
        private readonly ITestLogService _testLogService;
        public TestController(ITestService testService, ITestLogService testLogService)
        {
            _testService = testService;
            _testLogService = testLogService;
        }

        /// <summary>
        /// 测试依赖注入
        /// </summary>
        /// <returns></returns>
        [HttpGet("test/ioc"), AllowAnonymous]
        public async Task<IActionResult> TestIocAsync()
        {
            var test = await _testService.EatAsync();
            return Ok(test);
        }

        /// <summary>
        /// 测试日志记录
        /// </summary>
        /// <returns></returns>
        [HttpGet("test/log"), AllowAnonymous]
        public async Task TestLogAsync()
        {
            await _testLogService.WriteMsgeeageAsync();
        }
    }
}
