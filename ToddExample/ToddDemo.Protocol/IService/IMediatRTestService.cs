using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Protocol.IService
{
    public interface IMediatRTestService
    {
        /// <summary>
        /// 单播有返回值
        /// </summary>
        /// <returns></returns>
        Task<string> MediatRAddUserAsync();
        /// <summary>
        /// 单播无返回值
        /// </summary>
        /// <returns></returns>
        Task MediatRVoidAddUserAsync();
        /// <summary>
        /// 多播传递
        /// </summary>
        /// <returns></returns>
        Task MediatRNotifcationAddUserAsync();
    }
}
