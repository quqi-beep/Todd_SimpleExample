using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToddDemo.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToddDemo.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private CurrentUser _currentUser;
        public CurrentUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    GetCurrentUser();
                }
                return _currentUser;
            }
        }

        private void GetCurrentUser()
        {
            _currentUser = new CurrentUser
            {
                UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                UserName = User.FindFirst(ClaimTypes.Name).Value,
                Role = int.Parse(User.FindFirst(ClaimTypes.Role).Value)
            };
        }
    }
}