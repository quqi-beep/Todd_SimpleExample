using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.EventHandlers.Event
{
    /// <summary>
    /// 多播消息传递
    /// </summary>
    public class GenericNotification: INotification
    {
        public string Name { get; set; }
    }
}
