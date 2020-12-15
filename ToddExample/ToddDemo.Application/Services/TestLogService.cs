using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Extensions;
using ToddDemo.Protocol.IService;

namespace ToddDemo.Application.Services
{
    public class TestLogService : ITestLogService
    {
        private readonly ILogger _logger;
        public TestLogService(ILogger<TestLogService> logger)
        {
            _logger = logger;
        }

        public async Task WriteMsgeeageAsync()
        {
            await Task.Run(() =>
            {

            });

            _logger.LogInformation("测试Test......");
            //1.系统异常
            //throw new Exception("宝格错");
            
            //2.业务异常
            throw new KnownException(1111, "业务异常测试11");
            //throw new NotImplementedException();
        }
    }
}
