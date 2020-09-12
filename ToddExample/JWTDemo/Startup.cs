using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTDemo.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var audience = Configuration.GetSection("JwtSetting:Audience").Value;
                var issuer = Configuration.GetSection("JwtSetting:Issuer").Value;
                var key = Configuration.GetSection("JwtSetting:SecurityKey").Value;
                var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,  //Ê§Ð§Ê±¼ä
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    IssuerSigningKey= issuerSigningKey
                };
            });
            //services.AddHttpContextAccessor();
            //services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
