using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cdeem.Core.Entities;

namespace Cdeem.Core.Repositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task Delete(Skill skill);
    }
}