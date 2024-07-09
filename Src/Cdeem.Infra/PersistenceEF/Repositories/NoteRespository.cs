using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;
using Cdeem.Core.ValueObject;
using Cdeem.Infra.PersistenceEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.PersistenceEF.Repositories
{
    public class NoteRespository : INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Note> _notes;

        public NoteRespository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _notes = dbContext.Notes;
        }

        public async Task AddTaskAsync(Note note)
        {
            await _notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Note note)
        {
            _notes.Remove(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllBySkillAsync(Guid SkillId)
        {
            var querry = _notes.Include(x => x.Skill).AsQueryable().Where(x => x.Skill.Id == SkillId);

            return await querry.ToListAsync();
        }

        public async Task UpdateTaskAsync(Note note)
        {
            _notes.Update(note);
            var entityState = _dbContext.Entry(note.Skill).State;
            _dbContext.Entry(note.Skill).State =
                entityState == EntityState.Detached
                    ? EntityState.Added
                    : entityState;

            await _dbContext.SaveChangesAsync();
        }
    }
}
