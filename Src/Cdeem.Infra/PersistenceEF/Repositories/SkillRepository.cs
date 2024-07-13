using Cdeem.Core.Entities;
using Cdeem.Core.Repositories;
using Cdeem.Infra.PersistenceEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.PersistenceEF.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<Skill> _skill;

        public SkillRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _skill = dbContext.Skills;
        }

        public async Task AddAsync(Skill skill)
        {
            await _skill.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Skill skill)
        {
            _skill.Remove(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Skill> GetSkillAsync(Guid Id)
        {
            var querry = _skill.Include(u=>u.User).Include(s => s.Notes).AsQueryable().Where(s => s.Id == Id);

            return await querry.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Skill skill)
        {
            _skill.Update(skill);
            var entityState = _dbContext.Entry(skill.Notes).State;
            _dbContext.Entry(skill.Notes).State =
                entityState == EntityState.Detached
                    ? EntityState.Added
                    : entityState;

            await _dbContext.SaveChangesAsync();
        }
    }
}
