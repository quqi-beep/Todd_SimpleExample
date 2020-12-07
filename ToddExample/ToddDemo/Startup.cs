using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToddDemo.Extensions;
using ToddDemo.Infrastructure;
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
using ToddDemo.Application.Context;
using Microsoft.EntityFrameworkCore;
using ToddDemo.Application.Services;
using AutoMapper;
using ToddDemo.Application.Infrastructure.AutoMapper;
using MediatR;
using ToddDemo.Application.EventHandlers.Event;
using ToddDemo.Application.EventHandlers;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ToddDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));

            //ע��JWT
            services.AddToddJwt(Configuration);

            //services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //Json Patch��Ҫ��� NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson();

            //ע��AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
                cfg.AddProfile(new UserProfiles());
            });

            //ע��Swagger
            services.AddToddSwagger();

            services.AddScoped<UserService>();
            services.AddScoped<MediatRTestService>();

            //ע��MySql�����ַ���
            var connectionStrings = Configuration.GetSection("ConnectionStrings").Value;
            services.AddDbContext<SpmContext>(options => options.UseMySQL(connectionStrings, b => b.MigrationsAssembly("ToddDemo.Application")));

            var s = typeof(GenericRequest);
            services.AddMediatR(s);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //autofac ���� ��ѡ
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Version V1");
                x.SwaggerEndpoint("/swagger/v2/swagger.json", "Test Version V2");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        //autofac ����
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ֱ����Autofacע�������Զ���� 
            builder.RegisterModule(new AutofacModuleRegisterExtension());
        }
    }
}
