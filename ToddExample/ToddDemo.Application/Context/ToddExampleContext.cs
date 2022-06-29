using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Context
{
    public class ToddExampleContext : DbContext
    {
        public ToddExampleContext(DbContextOptions<ToddExampleContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
