using Cdeem.Core.Entities;
using Cdeem.Core.ValueObject;
using Cdeem.Infra.PersistenceEF.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.PersistenceEF.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Note> Notes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMapping().Configure(modelBuilder.Entity<User>());
            new SkillsMapping().Configure(modelBuilder.Entity<Skill>());
            new NoteMapping().Configure(modelBuilder.Entity<Note>());
        }
    }
}
