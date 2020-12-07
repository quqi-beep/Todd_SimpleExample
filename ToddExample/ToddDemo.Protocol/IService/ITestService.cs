using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Protocol.IService
{
    public interface ITestService
    {
        Task<string> EatAsync();
    }
}
