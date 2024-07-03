using Cdeem.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Application.InputModels
{
    public record AddNoteInputModel(Guid SkillId,string Annotation, DateTime CreatedDate, AddUserInputModel User)
    {
        public Note ToEntity()
            => new Note(Annotation, CreatedDate, User.ToEntity());
    };
}
