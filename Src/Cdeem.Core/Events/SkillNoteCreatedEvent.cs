using Cdeem.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Core.Events
{
    public class SkillNoteCreatedEvent
    {
        public SkillNoteCreatedEvent(string contactEmail, string annotation, string skillTitle)
        {
            ContactEmail = contactEmail;
            Annotation = annotation;
            SkillTitle = skillTitle;
        }

        public string ContactEmail { get; private set; }

        public string Annotation { get; private set; }

        public string SkillTitle { get; set; }

    }
}
