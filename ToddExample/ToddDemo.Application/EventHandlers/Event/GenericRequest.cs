using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.EventHandlers.Event
{
    /// <summary>
    /// 单播消息传递（有返回值）
    /// </summary>
    public class GenericRequest : IRequest<string>
    {
        public string UserName { get; set; }

        public int Age { get; set; }
    }

    /// <summary>
    /// 单播消息传递（无返回值）
    /// </summary>
    public class GenericVoidRequest:IRequest
    {
        public string UserName { get; set; }

        public int Age { get; set; }
    }
}
