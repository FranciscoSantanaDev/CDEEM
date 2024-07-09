using Cdeem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Cdeem.Core.ValueObject
{
    public class Note : EntityBase
    {
        public Note(string annotation, DateTime createdDate) : base()
        {
            Annotation = annotation;
            CreatedDate = createdDate;
        }

        public Note(string annotation, DateTime createdDate, Guid skillId) : base()
        {
            Annotation = annotation;
            CreatedDate = createdDate;
            Skill = new Skill(skillId);
        }

        public string Annotation { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Skill Skill { get; private set; }
    }
}