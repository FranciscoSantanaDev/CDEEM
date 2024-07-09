using Cdeem.Core.Enum;
using Cdeem.Core.Entities;
using Cdeem.Core.ValueObject;
using Cdeem.Application.ViewModel;


namespace Cdeem.Application.InputModels
{

    public record AddSkillInputModel(string Title, string Description, IEnumerable<NoteInputModel> Notes, SkillLevel SkillLevel, bool IsPublic)
    {
        public Skill ToEntity()
            => new Skill(Title, Description, Notes.Select(n => n.ToValueObject()).ToList(), SkillLevel, IsPublic, Guid.Empty);
    };
    public record NoteInputModel(string Annotation)
    {
        public Note ToValueObject()
            => new Note(Annotation, DateTime.Now);
    };
}
