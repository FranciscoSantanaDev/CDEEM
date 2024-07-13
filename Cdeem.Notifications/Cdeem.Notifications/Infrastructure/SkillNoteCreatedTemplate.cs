namespace Cdeem.API.Infrastructure
{
    public class SkillNoteCreatedTemplate : IEmailTemplate
    {
        public SkillNoteCreatedTemplate(string annotation, string to, string skillTitle)
        {
            Subject = $"A note has been added to your skill";
            Content = $"Hi, how are you? This note was added your skill {skillTitle}: {annotation}";
            To = to;
        }

        public string Subject { get; set; }
        public string Content { get; set; }
        public string To { get; set; }
    }
}
