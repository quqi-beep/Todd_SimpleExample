using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddToddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Todd 测试 WebApi项目",
                    Version = "V1.0.0",
                    Description = "Test"
                });
                x.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Todd 测试 WebApi项目 (V2)",
                    Version = "V2.0.0",
                    Description = "Test"
                }); ;

                //获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）;
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "JWTDemo.xml");
                //需要显示控制器注释，只需要将第二个参数设置成true
                x.IncludeXmlComments(xmlPath, true);
            });
        }
    }
}
