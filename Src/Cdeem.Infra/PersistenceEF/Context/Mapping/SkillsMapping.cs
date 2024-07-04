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
    public class SkillsMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.Property(s=>s.Id)
                   .IsRequired();

            builder.HasKey(s => s.Id);

            builder.Property(s=>s.Title) 
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(s=>s.Description)
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(s => s.IsPublic)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(s => s.SkillLevel)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne(s=>s.User)
                   .WithMany(u=>u.Skills)
                   .HasPrincipalKey(s=>s.Id);

            builder.HasMany(s=>s.Notes)
                   .WithOne(n=>n.Skill)
                   .HasPrincipalKey(s=>s.Id); 
        }
    }
}
