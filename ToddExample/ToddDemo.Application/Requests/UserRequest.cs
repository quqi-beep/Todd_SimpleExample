using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Requests
{
    public class UserRequest
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
    }
}
