using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToddDemo.Extensions
{
    public static class JwtExtension
    {
        /// <summary>
        /// JWT 扩展
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddToddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var audience = configuration.GetSection("JwtSetting:Audience").Value;
                var issuer = configuration.GetSection("JwtSetting:Issuer").Value;
                var key = configuration.GetSection("JwtSetting:SecurityKey").Value;
                var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,  //失效时间
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey = issuerSigningKey
                };
            });
        }
    }
}
