using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Protocol.IService;

namespace ToddDemo.Protocol.Service
{
    public class TestService : ITestService
    {
        public async Task<string> EatAsync()
        {
            Console.WriteLine("这是一个测试服务");
            return await Task.FromResult("这是一个测试服务");
        }
    }
}
