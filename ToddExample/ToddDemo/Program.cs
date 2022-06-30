using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToddDemo.Application.Context;
using ToddDemo.Application.EventHandlers.Event;
using ToddDemo.Application.Infrastructure.AutoMapper;
using ToddDemo.Extensions;
using ToddDemo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegisterExtension());
});
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));
//注入JWT
builder.Services.AddToddJwt(builder.Configuration);
//Json Patch需要添加 NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();
//注入AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AutoMapperProfiles>();
    cfg.AddProfile(new UserProfiles());
});
//注入Swagger
builder.Services.AddToddSwagger();
//注入MySql连接字符串
var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Value;
builder.Services.AddDbContext<ToddExampleContext>(options => options.UseMySQL(connectionStrings, b => b.MigrationsAssembly("ToddDemo.Application")));
builder.Services.AddMediatR(typeof(GenericRequest));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Version V1");
        x.SwaggerEndpoint("/swagger/v2/swagger.json", "Test Version V2");
    });
}
app.UseCustomExceptionMiddleware();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

