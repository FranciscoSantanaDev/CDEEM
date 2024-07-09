using Cdeem.Application.InputModels;
using Cdeem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.Services
{
    public class SkillService : ISkillServices
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(AddSkillInputModel model)
        {
           var skill = model.ToEntity();
            await _repository.AddAsync(skill);
        }

        public async Task AddAsyncNote(AddNoteInputModel model)
        {
            var skill = await _repository.GetSkillAsync(model.SkillId);
            skill.AddNote(model.ToEntity());
            await _repository.UpdateAsync(skill);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<SkillViewModel> GetSkillAsync(Guid Id)
        {
          return SkillViewModel.FromEntity(await _repository.GetSkillAsync(Id));
        }

        public async Task UpdateAsync(AddSkillInputModel model)
        {
            var skill = model.ToEntity();
            await _repository.UpdateAsync(skill);
        }
    }
}
