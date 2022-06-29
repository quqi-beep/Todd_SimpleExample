using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Context
{
    public class ToddExampleDbContextFactory : IDesignTimeDbContextFactory<ToddExampleContext>
    {
        public ToddExampleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToddExampleContext>();
            builder.UseMySQL("server=dev_mysql01.fnlinker.com;port=6306;database=toddexample;user=fnlinker;password=123456");
            return new ToddExampleContext(builder.Options);
        }
    }
}
