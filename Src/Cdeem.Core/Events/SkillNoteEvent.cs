using Cdeem.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Core.Events
{
    public class SkillNoteEvent
    {
        public SkillNoteEvent(string contactEmail , Note note)
        { 
            ContactEmail = contactEmail;
            Note = note;
        }

        public string ContactEmail { get; private set; }

        public Note Note { get; private set; }
    }
}
