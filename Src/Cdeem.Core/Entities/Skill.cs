using Cdeem.Core.Enum;
using Cdeem.Core.ValueObject;

namespace Cdeem.Core.Entities
{
    public class Skill : EntityBase
    {
        public Skill(string title, string description, IEnumerable<Note> notes, SkillLevel skillLevel,bool isPublic) : base()
        {
            Title = title;
            Description = description;
            Notes = notes;
            SkillLevel = skillLevel;
             IsPublic = isPublic;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Note> Notes { get; private set; }
        public SkillLevel SkillLevel{ get; private set; } = SkillLevel.Beginner;
        public bool IsPublic { get; private set; }
    }
}