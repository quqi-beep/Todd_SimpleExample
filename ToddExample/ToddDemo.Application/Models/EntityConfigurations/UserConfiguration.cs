using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToddDemo.Application.Models.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserName).IsRequired().HasColumnType("varchar(50)").HasDefaultValue("");
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(20)").HasDefaultValue("");
            builder.Property(x => x.Age).IsRequired();
        }
    }
}
