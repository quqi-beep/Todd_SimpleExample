using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Context
{
    public class SpmContext : DbContext
    {
        //public SpmContext()
        //{

        //}

        public SpmContext(DbContextOptions<SpmContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
