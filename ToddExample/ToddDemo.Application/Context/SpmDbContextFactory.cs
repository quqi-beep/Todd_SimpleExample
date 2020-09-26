using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Context
{
    public class SpmDbContextFactory : IDesignTimeDbContextFactory<SpmContext>
    {
        public SpmContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SpmContext>();
            builder.UseMySQL("server=dev_mysql01.fnlinker.com;port=6306;database=fnlinker.spm;user=fnlinker;password=123456");
            return new SpmContext(builder.Options);
        }
    }
}
