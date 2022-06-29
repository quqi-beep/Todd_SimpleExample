using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Application.Context;
using ToddDemo.Application.EventHandlers.Event;
using ToddDemo.Protocol.IService;

namespace ToddDemo.Application.Services
{
    public class MediatRTestService : IMediatRTestService
    {
        private readonly ToddExampleContext _context;
        private readonly IMediator _mediator;
        public MediatRTestService(ToddExampleContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        /// <summary>
        /// 单播有返回值
        /// </summary>
        /// <returns></returns>
        public async Task<string> MediatRAddUserAsync()
        {
            var res = await _mediator.Send(new GenericRequest
            {
                Age = 50,
                UserName = "测试MediatR"
            });
            return res;
        }
        /// <summary>
        /// 单播无返回值
        /// </summary>
        /// <returns></returns>
        public async Task MediatRVoidAddUserAsync()
        {
            await _mediator.Send(new GenericVoidRequest
            {
                UserName = "测试MediatR单播无参模式",
                Age = 20
            });
        }

        public async Task MediatRNotifcationAddUserAsync()
        {
            await _mediator.Publish(new GenericNotification
            {
                Name = "测试MediatR多播"
            });
        }
    }
}
