using Cdeem.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Core.Repositories
{
    public interface INoteRepository
    {
        Task AddTaskAsync(Note note);
        Task UpdateTaskAsync(Note note);
        Task DeleteTaskAsync(Note note);
        Task<List<Note>> GetAllBySkillAsync(Guid SkillId);
    }
}
