using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Protocol.IService
{
    public interface IMediatRTestService
    {
        Task<string> MediatRAddUserAsync();

        Task MediatRVoidAddUserAsync();

        Task MediatRNotifcationAddUserAsync();
    }
}
