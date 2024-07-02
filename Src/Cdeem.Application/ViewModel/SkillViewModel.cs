using Cdeem.Core.Enum;
using Cdeem.Core.Entities;
using Cdeem.Core.ValueObject;


namespace Cdeem.Application.InputModels
{
    public record SkillViewModel(string Title, string Description, IEnumerable<NoteViewModel> Notes, SkillLevel SkillLevel, bool IsPublic)
    {
        public static SkillViewModel FromEntity(Skill skill) => new SkillViewModel(skill.Title, skill.Description,skill.Notes.Select(NoteViewModel.FromValueObject),skill.SkillLevel,skill.IsPublic);
    };
    public record NoteViewModel(string Annotation, DateTime CreatedDate)
    {
        public static NoteViewModel FromValueObject(Note note) => new  NoteViewModel(note.Annotation, note.CreatedDate);
    };
}
