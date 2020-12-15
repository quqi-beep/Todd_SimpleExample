﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ToddDemo.Application.Services;

namespace ToddDemo.Extensions
{
    /// <summary>
    /// Autofac扩展
    /// </summary>
    public class AutofacModuleRegisterExtension : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册Service中的对象,Service中的类要以Service结尾，否则注册失败
            builder.RegisterAssemblyTypes(typeof(TestLogService).Assembly).Where(a => a.Name.EndsWith("Service") || a.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();   ///GetAssemblyByName("ToddDemo.Protocol")

            //注册Repository中的对象,Repository中的类要以Repository结尾，否则注册失败
            //builder.RegisterAssemblyTypes(GetAssemblyByName("ToddDemo.Protocol")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }

        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssemblyByName(string AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }
    }
}
