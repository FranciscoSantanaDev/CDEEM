using Cdeem.Application.InputModels;
using Cdeem.Core.Events;
using Cdeem.Core.Repositories;
using Cdeem.Infra.Messaging;
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
        private readonly IMessageBusService _messageBusService;

        public SkillService(ISkillRepository repository, IMessageBusService messageBusService)
        {
            _repository = repository;
            _messageBusService = messageBusService;
        }

        public async Task AddAsync(AddSkillInputModel model)
        {
           var skill = model.ToEntity();
            await _repository.AddAsync(skill);
        }

        public async Task AddAsyncNote(AddNoteInputModel model)
        {
            var skill = await _repository.GetSkillAsync(model.SkillId);
            //skill.AddNote(model.ToEntity());
            //await _repository.UpdateAsync(skill);



            var skillNoteEvent = new SkillNoteCreatedEvent(skill.User.Email, model.Annotation,skill.Title);
            _messageBusService.Publish(skillNoteEvent, "Skill-Note-Created");
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
