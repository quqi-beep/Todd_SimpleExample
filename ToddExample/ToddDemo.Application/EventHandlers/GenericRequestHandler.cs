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
    public class GenericRequestHandler : IRequestHandler<GenericRequest, string>
    {
        private readonly SpmContext _context;

        public GenericRequestHandler(SpmContext context)
        {
            _context = context;
        }


        public async Task<string> Handle(GenericRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Age = request.Age,
                Password = "123456",
                UserName = request.UserName
            };
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();

            return request.UserName;
        }
    }


    public class GenericVoidRequestHandler : AsyncRequestHandler<GenericVoidRequest>
    {
        private readonly SpmContext _context;

        public GenericVoidRequestHandler(SpmContext context)
        {
            _context = context;
        }


        protected override async Task Handle(GenericVoidRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Age = request.Age,
                Password = "123456",
                UserName = request.UserName
            };
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
