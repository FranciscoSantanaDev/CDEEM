using Cdeem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.PersistenceEF.Context.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder
                .Property(e => e.Id)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(e => e.Password)
                   .HasColumnType("varchar(150)")
                   .IsRequired();
        }
    }
}
