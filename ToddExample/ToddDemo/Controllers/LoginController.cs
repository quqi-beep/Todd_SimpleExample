using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Infrastructure;
using ToddDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace ToddDemo.Controllers
{
    [Route("login")]
    public class LoginController : AuthController
    {
        private readonly User _user;
        private readonly JwtSetting _jwtSetting;

        public LoginController(IOptions<JwtSetting> options)
        {
            _user = new User
            {
                Id = 1,
                Name = "todd",
                Password = "123456"
            };
            _jwtSetting = options.Value;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Login(string name, string password)
        {
            if (_user.Name == name && _user.Password == password)
            {
                var (token, expires) = GetToken(_user);
                return Ok(new { Token = token, ExpireTime = expires, Message = "Get Token Success" });
            }
            return Ok(new { Message = "Get Token Fail" });
        }

        private (string, string) GetToken(User user)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,"1")
            };

            var expires = DateTime.Now.AddHours(_jwtSetting.ExpireSeconds);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey));
            var token = new JwtSecurityToken(
                     issuer: _jwtSetting.Issuer,
                     audience: _jwtSetting.Audience,
                     claims: claims,
                     notBefore: DateTime.Now,
                     expires: expires,
                     signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return (jwtToken, expires.ToString("yyyy-MM-dd HH:mm:ss"));
        }


    }
}