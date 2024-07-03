using Cdeem.Application.InputModels;
using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.Services
{
    public interface ISkillServices
    {
        Task AddAsync(AddSkillInputModel model);
        Task UpdateAsync(AddSkillInputModel model);
        Task Delete(Guid id);
        Task<SkillViewModel> GetSkillAsync(Guid Id);
        Task AddNote(AddNoteInputModel model);
    }
}
