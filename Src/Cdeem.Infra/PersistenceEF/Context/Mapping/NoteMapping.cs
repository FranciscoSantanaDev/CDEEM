using Cdeem.Core.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.PersistenceEF.Context.Mapping
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");

            builder.Property(n=>n.Id)
                   .IsRequired();
            
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Annotation)
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(n=>n.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();
        }
    }
}
