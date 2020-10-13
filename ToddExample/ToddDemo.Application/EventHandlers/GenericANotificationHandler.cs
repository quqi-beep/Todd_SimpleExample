using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToddDemo.Application.Context;
using ToddDemo.Application.EventHandlers.Event;

namespace ToddDemo.Application.EventHandlers
{
    /// <summary>
    /// 多播处理程序1
    /// </summary>
    public class GenericANotificationHandler : INotificationHandler<GenericNotification>
    {
        private readonly SpmContext _context;

        public GenericANotificationHandler(SpmContext context)
        {
            _context = context;
        }

        public async Task Handle(GenericNotification notification, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Age = 20,
                Password = "123456",
                UserName = notification.Name + "1"
            };
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// 多播处理程序2
    /// </summary>
    public class GenericBNotificationHandler : INotificationHandler<GenericNotification>
    {
        private readonly SpmContext _context;

        public GenericBNotificationHandler(SpmContext context)
        {
            _context = context;
        }
        public async Task Handle(GenericNotification notification, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Age = 20,
                Password = "123456",
                UserName = notification.Name + "2"
            };
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
