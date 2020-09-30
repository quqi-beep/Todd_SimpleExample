using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UsersResponse
    {
        public List<UserDto> Users { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }

    public class UserAgeDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
    }
}
